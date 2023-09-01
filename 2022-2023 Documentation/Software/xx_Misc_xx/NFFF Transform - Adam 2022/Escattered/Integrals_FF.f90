!*************************************************************************************

Subroutine FINDUFF(ih,jh,kh,														&
					nglu,nglv,nglw,													&
					wglu,wglv,wglw,													&
					elem,numberOfElements,face,										&
					uPowers,fvPowers,fwPowers,										&
					fpvPowers,fpwPowers,											&
					auMatrix,avMatrix,awMatrix,jacobianMatrix,						&
					rMatrix,														&
					k0,iR,															&
					cUFF)	! See XIII-6
!~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
!	ih, jh, kh - indeksi i^, j^, k^
!	nglu, nglv, nglw - redovi GL integracije
!	xglu, xglv, xglw - koordinate za GL integraciju
!	wglu, wglv, wglw - tezinski koeficijenti za GL integraciju
!	elem - indeks elementa
!	numberOfElements - ukupan broj elemenata
!	ru,rv,rw,ruv,ruw,rvw,ruvw - konstantni vektori za dati element
!	muRelative - mi relativno (niz realnih i imaginarnih delova mi za homogenu sredinu)
!	cUFF - Far Field Integral UFF

	Integer elem, numberOfElements
	Integer*1 face
	Integer ih,jh,kh
	Integer nglu(numberOfElements), nglv(numberOfElements), nglw(numberOfElements)
	Real*8    wglu(nglu(elem)),       wglv(nglv(elem)),       wglw(nglw(elem))
	Real*8    uPowers(0:nglu(elem)+1,0:*), fvPowers(0:nglv(elem)+1,0:*), fwPowers(0:nglw(elem)+1,0:*)
	Real*8  fpvPowers(0:nglv(elem)+1,0:*),fpwPowers(0:nglw(elem)+1,0:*)
	Real*8    auMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8    avMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8    awMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8	   rMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8    jacobianMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1)
	Real*8     k0
	Real*8     iR(3)	! Jedinicni vektor u pravcu u kome se trazi Esc.
	Complex*16 cUFF(3)
	
	Real*8 au(3),av(3),aw(3),ausec(3),avsec(3),awsec(3),r(3),vec1(3),vec2(3),rfus(3),jacobian,fu
	Real*8 rir	! Skalarni proizvod r' i ir
	
	Integer m,n,l			! Brojaci suma za trostruku GL Integraciju
	Complex*16 cSl(3),cSn(3)! Medju sume
	Integer*1 sign1,sign2	! Znaci koji zavise od povrsi

	Complex*16 czero, cone, cj

	Common /kompleks/ czero, cone, cj

	cUFF(:) = czero

	Select Case (face)
	Case(1,2)

		Select case (face)
		Case (1)				! u=-1 => m=0   See V-4, XII-21
			m = 0
			sign2 = -1
		Case (2)				! u=+1 => m=NGLu+1   See V-4, XII-21
		    m = nglu(elem)+1	
			sign2 =  1
		End Select

		Do 	n=1,nglv(elem)
			cSl(:) = czero
			Do l=1,nglw(elem)

				av(:) = avMatrix(m,n,l,:)
				aw(:) = awMatrix(m,n,l,:)
				r(:)  =  rMatrix(m,n,l,:)
				jacobian = jacobianMatrix(m,n,l)
				
				Call DOTPROD(r,iR,rir)
				Call FINDAUSEC(av,aw,ausec)
				Call ROTFUSEC(m,n,l,ih,jh,kh,av,aw,uPowers,fvPowers,fwPowers,fpvPowers,fpwPowers,	&
								nglu,nglv,nglw,elem,rfus)
				Call CROSSPROD(ausec,rfus,vec2)

				cSl(:) = cSl(:) + wglw(l) * CDexp(cj*k0*rir) * vec2(:) / jacobian * sign2 
			End Do
			cUFF(:) = cUFF(:) + wglv(n) * cSl(:)
		End Do

	Case(3,4)

		Select case (face)
		Case (3)				! v=-1 => n=0   See V-4, XII-21
			n = 0
			sign1 =  1			! See XIII-6
			sign2 = -1
		Case (4)				! v=+1 => n=NGLv+1   See V-4, XII-21
		    n = nglv(elem)+1	
			sign1 = -1			! See XIII-6
			sign2 =  1
		End Select

		Do 	m=1,nglu(elem)
			cSl(:) = czero
			Do l=1,nglw(elem)

				au(:) = auMatrix(m,n,l,:)
				av(:) = avMatrix(m,n,l,:)
				aw(:) = awMatrix(m,n,l,:)
				r(:) =   rMatrix(m,n,l,:)
				jacobian = jacobianMatrix(m,n,l)

				Call FUODUVW(m,n,l,ih,jh,kh,uPowers,fvPowers,fwPowers,nglu,nglv,nglw,elem,fu)
				Call DOTPROD(r,iR,rir)
				Call CROSSPROD(aw,iR,vec1)

				Call FINDAVSEC(aw,au,avsec)
				Call ROTFUSEC(m,n,l,ih,jh,kh,av,aw,uPowers,fvPowers,fwPowers,fpvPowers,fpwPowers,	&
								nglu,nglv,nglw,elem,rfus)
				Call CROSSPROD(avsec,rfus,vec2)

				cSl(:) = cSl(:) + wglw(l)*CDexp(cj*k0*rir)*(cj*k0*fu*vec1(:)*sign1 + vec2(:)/jacobian*sign2)

			End Do
			cUFF(:) = cUFF(:) + wglu(m) * cSl(:)
		End Do

	Case (5,6)

		Select case (face)
		Case (5)				! w=-1 => l=0   See V-4, XII-21
			l = 0
			sign1 = -1			! See XIII-6
			sign2 = -1
		Case (6)				! w=+1 => l=NGLw+1   See V-4, XII-21
		    l = nglw(elem)+1	
			sign1 =  1			! See XIII-6
			sign2 =  1
		End Select

		Do 	m=1,nglu(elem)
			cSn(:) = czero
			Do n=1,nglv(elem)

				au(:) = auMatrix(m,n,l,:)
				av(:) = avMatrix(m,n,l,:)
				aw(:) = awMatrix(m,n,l,:)
				r(:) =   rMatrix(m,n,l,:)
				jacobian = jacobianMatrix(m,n,l)

				Call FUODUVW(m,n,l,ih,jh,kh,uPowers,fvPowers,fwPowers,nglu,nglv,nglw,elem,fu)
				Call DOTPROD(r,iR,rir)
				Call CROSSPROD(av,iR,vec1)

				Call FINDAWSEC(au,av,awsec)
				Call ROTFUSEC(m,n,l,ih,jh,kh,av,aw,uPowers,fvPowers,fwPowers,fpvPowers,fpwPowers,	&
								nglu,nglv,nglw,elem,rfus)
				Call CROSSPROD(awsec,rfus,vec2)

				cSn(:) = cSn(:) + wglv(n)*CDexp(cj*k0*rir)*(cj*k0*fu*vec1(:)*sign1 + vec2(:)/jacobian*sign2)
			End Do
			cUFF(:) = cUFF(:) + wglu(m) * cSn(:)
		End Do

	End Select
			
Return
End	Subroutine FINDUFF

!*************************************************************************************

Subroutine FINDVFF(ih,jh,kh,														&
					nglu,nglv,nglw,													&
					wglu,wglv,wglw,													&
					elem,numberOfElements,face,										&
					fuPowers,vPowers,fwPowers,										&
					fpuPowers,fpwPowers,											&
					auMatrix,avMatrix,awMatrix,jacobianMatrix,						&
					rMatrix,														&
					k0,iR,															&
					cVFF)	! See XIII-6
!~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
!	ih, jh, kh - indeksi i^, j^, k^
!	nglu, nglv, nglw - redovi GL integracije
!	xglu, xglv, xglw - koordinate za GL integraciju
!	wglu, wglv, wglw - tezinski koeficijenti za GL integraciju
!	elem - indeks elementa
!	numberOfElements - ukupan broj elemenata
!	ru,rv,rw,ruv,ruw,rvw,ruvw - konstantni vektori za dati element
!	muRelative - mi relativno (niz realnih i imaginarnih delova mi za homogenu sredinu)
!	cVFF - Far Field Integral VFF

	Integer elem, numberOfElements
	Integer*1 face
	Integer ih,jh,kh
	Integer nglu(numberOfElements), nglv(numberOfElements), nglw(numberOfElements)
	Real*8    wglu(nglu(elem)),       wglv(nglv(elem)),       wglw(nglw(elem))
	Real*8    fuPowers(0:nglu(elem)+1,0:*),  vPowers(0:nglv(elem)+1,0:*), fwPowers(0:nglw(elem)+1,0:*)
	Real*8   fpuPowers(0:nglv(elem)+1,0:*),fpwPowers(0:nglw(elem)+1,0:*)
	Real*8    auMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8    avMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8    awMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8	   rMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8    jacobianMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1)
	Real*8     k0
	Real*8     iR(3)	! Jedinicni vektor u pravcu u kome se trazi Esc.
	Complex*16 cVFF(3)
	
	Real*8 au(3),av(3),aw(3),ausec(3),avsec(3),awsec(3),r(3),vec1(3),vec2(3),rfvs(3),jacobian,fv
	Real*8 rir	! Skalarni proizvod r' i ir
	
	Integer m,n,l			! Brojaci suma za trostruku GL Integraciju
	Complex*16 cSl(3),cSn(3)! Medju sume
	Integer*1 sign1,sign2	! Znaci koji zavise od povrsi

	Complex*16 czero, cone, cj

	Common /kompleks/ czero, cone, cj

	cVFF(:) = czero

	Select Case (face)
	Case(1,2)

		Select case (face)
		Case (1)				! u=-1 => m=0   See V-4, XII-21
			m = 0
			sign1 = -1
			sign2 = -1
		Case (2)				! u=+1 => m=NGLu+1   See V-4, XII-21
		    m = nglu(elem)+1	
			sign1 =  1
			sign2 =  1
		End Select

		Do 	n=1,nglv(elem)
			cSl(:) = czero
			Do l=1,nglw(elem)

				au(:) = auMatrix(m,n,l,:)
				av(:) = avMatrix(m,n,l,:)
				aw(:) = awMatrix(m,n,l,:)
				r(:)  =  rMatrix(m,n,l,:)
				jacobian = jacobianMatrix(m,n,l)

				Call FVODUVW(m,n,l,ih,jh,kh,fuPowers,vPowers,fwPowers,nglu,nglv,nglw,elem,fv)				
				Call DOTPROD(r,iR,rir)
				Call CROSSPROD(aw,iR,vec1)

				Call FINDAUSEC(av,aw,ausec)
				Call ROTFVSEC(m,n,l,ih,jh,kh,aw,au,vPowers,fuPowers,fwPowers,fpuPowers,fpwPowers,	&
								nglu,nglv,nglw,elem,rfvs)
				Call CROSSPROD(ausec,rfvs,vec2)

				cSl(:) = cSl(:) + wglw(l)*CDexp(cj*k0*rir)*(cj*k0*fv*vec1(:)*sign1 + vec2(:)/jacobian*sign2) 
			End Do
			cVFF(:) = cVFF(:) + wglv(n) * cSl(:)
		End Do

	Case(3,4)

		Select case (face)
		Case (3)				! v=-1 => n=0   See V-4, XII-21
			n = 0
			sign2 = -1
		Case (4)				! v=+1 => n=NGLv+1   See V-4, XII-21
		    n = nglv(elem)+1	
			sign2 =  1
		End Select

		Do 	m=1,nglu(elem)
			cSl(:) = czero
			Do l=1,nglw(elem)

				au(:) = auMatrix(m,n,l,:)
				aw(:) = awMatrix(m,n,l,:)
				r(:) =   rMatrix(m,n,l,:)
				jacobian = jacobianMatrix(m,n,l)

				Call DOTPROD(r,iR,rir)

				Call FINDAVSEC(aw,au,avsec)
				Call ROTFVSEC(m,n,l,ih,jh,kh,aw,au,vPowers,fuPowers,fwPowers,fpuPowers,fpwPowers,	&
								nglu,nglv,nglw,elem,rfvs)
				Call CROSSPROD(avsec,rfvs,vec2)

				cSl(:) = cSl(:) + wglw(l) * CDexp(cj*k0*rir) * vec2(:) / jacobian * sign2

			End Do
			cVFF(:) = cVFF(:) + wglu(m) * cSl(:)
		End Do

	Case (5,6)

		Select case (face)
		Case (5)				! w=-1 => l=0   See V-4, XII-21
			l = 0
			sign1 =  1			! See XIII-6
			sign2 = -1
		Case (6)				! w=+1 => l=NGLw+1   See V-4, XII-21
		    l = nglw(elem)+1	
			sign1 = -1			! See XIII-6
			sign2 =  1
		End Select

		Do 	m=1,nglu(elem)
			cSn(:) = czero
			Do n=1,nglv(elem)

				au(:) = auMatrix(m,n,l,:)
				av(:) = avMatrix(m,n,l,:)
				aw(:) = awMatrix(m,n,l,:)
				r(:) =   rMatrix(m,n,l,:)
				jacobian = jacobianMatrix(m,n,l)

				Call FVODUVW(m,n,l,ih,jh,kh,fuPowers,vPowers,fwPowers,nglu,nglv,nglw,elem,fv)
				Call DOTPROD(r,iR,rir)
				Call CROSSPROD(au,iR,vec1)

				Call FINDAWSEC(au,av,awsec)
				Call ROTFVSEC(m,n,l,ih,jh,kh,aw,au,vPowers,fuPowers,fwPowers,fpuPowers,fpwPowers,	&
								nglu,nglv,nglw,elem,rfvs)
				Call CROSSPROD(awsec,rfvs,vec2)

				cSn(:) = cSn(:) + wglv(n)*CDexp(cj*k0*rir)*(cj*k0*fv*vec1(:)*sign1 + vec2(:)/jacobian*sign2)
			End Do
			cVFF(:) = cVFF(:) + wglu(m) * cSn(:)
		End Do

	End Select
			
Return
End	Subroutine FINDVFF

!*************************************************************************************

Subroutine FINDWFF(ih,jh,kh,														&
					nglu,nglv,nglw,													&
					wglu,wglv,wglw,													&
					elem,numberOfElements,face,										&
					fuPowers,fvPowers,wPowers,										&
					fpuPowers,fpvPowers,											&
					auMatrix,avMatrix,awMatrix,jacobianMatrix,						&
					rMatrix,														&
					k0,iR,															&
					cWFF)	! See XIII-6
!~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
!	ih, jh, kh - indeksi i^, j^, k^
!	nglu, nglv, nglw - redovi GL integracije
!	xglu, xglv, xglw - koordinate za GL integraciju
!	wglu, wglv, wglw - tezinski koeficijenti za GL integraciju
!	elem - indeks elementa
!	numberOfElements - ukupan broj elemenata
!	ru,rv,rw,ruv,ruw,rvw,ruvw - konstantni vektori za dati element
!	muRelative - mi relativno (niz realnih i imaginarnih delova mi za homogenu sredinu)
!	cWFF - Far Field Integral WFF

	Integer elem, numberOfElements
	Integer*1 face
	Integer ih,jh,kh
	Integer nglu(numberOfElements), nglv(numberOfElements), nglw(numberOfElements)
	Real*8    wglu(nglu(elem)),       wglv(nglv(elem)),       wglw(nglw(elem))
	Real*8    fuPowers(0:nglu(elem)+1,0:*), fvPowers(0:nglv(elem)+1,0:*), wPowers(0:nglw(elem)+1,0:*)
	Real*8   fpuPowers(0:nglv(elem)+1,0:*),fpvPowers(0:nglw(elem)+1,0:*)
	Real*8    auMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8    avMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8    awMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8	   rMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1,3)
	Real*8    jacobianMatrix(0:nglu(elem)+1,0:nglv(elem)+1,0:nglw(elem)+1)
	Real*8     k0
	Real*8     iR(3)	! Jedinicni vektor u pravcu u kome se trazi Esc.
	Complex*16 cWFF(3)
	
	Real*8 au(3),av(3),aw(3),ausec(3),avsec(3),awsec(3),r(3),vec1(3),vec2(3),rfws(3),jacobian,fw
	Real*8 rir	! Skalarni proizvod r' i ir
	
	Integer m,n,l			! Brojaci suma za trostruku GL Integraciju
	Complex*16 cSl(3),cSn(3)! Medju sume
	Integer*1 sign1,sign2	! Znaci koji zavise od povrsi

	Complex*16 czero, cone, cj

	Common /kompleks/ czero, cone, cj

	cWFF(:) = czero

	Select Case (face)
	Case(1,2)

		Select case (face)
		Case (1)				! u=-1 => m=0   See V-4, XII-21
			m = 0
			sign1 =  1
			sign2 = -1
		Case (2)				! u=+1 => m=NGLu+1   See V-4, XII-21
		    m = nglu(elem)+1	
			sign1 = -1
			sign2 =  1
		End Select

		Do 	n=1,nglv(elem)
			cSl(:) = czero
			Do l=1,nglw(elem)

				au(:) = auMatrix(m,n,l,:)
				av(:) = avMatrix(m,n,l,:)
				aw(:) = awMatrix(m,n,l,:)
				r(:)  =  rMatrix(m,n,l,:)
				jacobian = jacobianMatrix(m,n,l)

				Call FWODUVW(m,n,l,ih,jh,kh,fuPowers,fvPowers,wPowers,nglu,nglv,nglw,elem,fw)				
				Call DOTPROD(r,iR,rir)
				Call CROSSPROD(av,iR,vec1)

				Call FINDAUSEC(av,aw,ausec)
				Call ROTFWSEC(m,n,l,ih,jh,kh,au,av,wPowers,fuPowers,fvPowers,fpuPowers,fpvPowers,	&
								nglu,nglv,nglw,elem,rfws)
				Call CROSSPROD(ausec,rfws,vec2)

				cSl(:) = cSl(:) + wglw(l)*CDexp(cj*k0*rir)*(cj*k0*fw*vec1(:)*sign1 + vec2(:)/jacobian*sign2) 
			End Do
			cWFF(:) = cWFF(:) + wglv(n) * cSl(:)
		End Do

	Case(3,4)

		Select case (face)
		Case (3)				! v=-1 => n=0   See V-4, XII-21
			n = 0
			sign1 = -1
			sign2 = -1
		Case (4)				! v=+1 => n=NGLv+1   See V-4, XII-21
		    n = nglv(elem)+1	
			sign1 =  1
			sign2 =  1
		End Select

		Do 	m=1,nglu(elem)
			cSl(:) = czero
			Do l=1,nglw(elem)

				au(:) = auMatrix(m,n,l,:)
				av(:) = avMatrix(m,n,l,:)
				aw(:) = awMatrix(m,n,l,:)
				r(:) =   rMatrix(m,n,l,:)
				jacobian = jacobianMatrix(m,n,l)

				Call FWODUVW(m,n,l,ih,jh,kh,fuPowers,fvPowers,wPowers,nglu,nglv,nglw,elem,fw)				
				Call DOTPROD(r,iR,rir)
				Call CROSSPROD(au,iR,vec1)

				Call FINDAVSEC(aw,au,avsec)
				Call ROTFWSEC(m,n,l,ih,jh,kh,au,av,wPowers,fuPowers,fvPowers,fpuPowers,fpvPowers,	&
								nglu,nglv,nglw,elem,rfws)
				Call CROSSPROD(avsec,rfws,vec2)

				cSl(:) = cSl(:) + wglw(l)*CDexp(cj*k0*rir)*(cj*k0*fw*vec1(:)*sign1 + vec2(:)/jacobian*sign2) 

			End Do
			cWFF(:) = cWFF(:) + wglu(m) * cSl(:)
		End Do

	Case (5,6)

		Select case (face)
		Case (5)				! w=-1 => l=0   See V-4, XII-21
			l = 0
			sign2 = -1
		Case (6)				! w=+1 => l=NGLw+1   See V-4, XII-21
		    l = nglw(elem)+1	
			sign2 =  1
		End Select

		Do 	m=1,nglu(elem)
			cSn(:) = czero
			Do n=1,nglv(elem)

				au(:) = auMatrix(m,n,l,:)
				av(:) = avMatrix(m,n,l,:)
				r(:) =   rMatrix(m,n,l,:)
				jacobian = jacobianMatrix(m,n,l)

				Call DOTPROD(r,iR,rir)

				Call FINDAWSEC(au,av,awsec)
				Call ROTFWSEC(m,n,l,ih,jh,kh,au,av,wPowers,fuPowers,fvPowers,fpuPowers,fpvPowers,	&
								nglu,nglv,nglw,elem,rfws)
				Call CROSSPROD(awsec,rfws,vec2)

				cSn(:) = cSn(:) + wglv(n) * CDexp(cj*k0*rir) * vec2(:) / jacobian * sign2
			End Do
			cWFF(:) = cWFF(:) + wglu(m) * cSn(:)
		End Do

	End Select
			
Return
End	Subroutine FINDWFF

!*************************************************************************************