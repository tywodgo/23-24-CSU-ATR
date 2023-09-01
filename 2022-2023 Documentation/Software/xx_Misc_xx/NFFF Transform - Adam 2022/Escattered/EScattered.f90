!*************************************************************************************

Subroutine FINDESC(indicatorBasisType,									&
					numberOfElements,elementOrders,abcList,				& ! Racuna E scattered
					rs,nu,nv,nw,										& ! za pobudu u obliku ravnog talasa
			 		nglu,nglv,nglw,										&
					matDimDis,matDimCon,eiUVWijk,vectorD,cAlpha,		&
					k0,iR,												&
					cEsc) 

	Integer*1 indicatorBasisType
	Integer numberOfElements
	Integer*1 abcList(numberOfElements,6)
	Integer*1 elementOrders(numberOfElements)
	Integer matDimDis,matDimCon,vectorD(matDimDis)
	Complex*16 cAlpha(matDimCon)
	Integer eiUVWijk(matDimDis,5)
	Real*8    k0, iR(3)
	Complex*16 cEsc(3)

	Integer nu(numberOfElements), nv(numberOfElements), nw(numberOfElements)
	Integer nglu(numberOfElements), nglv(numberOfElements), nglw(numberOfElements)
	Real*8    rs(numberOfElements,125,3)
	Real*8, Allocatable :: xglu(:), wglu(:)	! GL Int points and weights (nglu(element)) 
	Real*8, Allocatable :: xglv(:), wglv(:)	! GL Int points and weights (nglv(element))
	Real*8, Allocatable :: xglw(:), wglw(:)	! GL Int points and weights (nglw(element))
	Real*8, Allocatable :: uPowers(:,:)		! Matrice dimenzija (nglu,nu+1),(nglv,nv+1),(nglw,nw+1) sa stepenima koordinata
	Real*8, Allocatable :: vPowers(:,:)		! u^i, v^j i w^k u tackama odredjenim gausovom podelom za integraciju.
	Real*8, Allocatable :: wPowers(:,:)		! 		0	1	  2	   3		  nu
	Real*8, Allocatable :: fuPowers(:,:)	!   1	1	u1  u1^2  u1^3  ...  u1^nu
	Real*8, Allocatable :: fvPowers(:,:)	!  ...
	Real*8, Allocatable :: fwPowers(:,:)	! nglu  1	unglu ...            unglu^nu
	Real*8, Allocatable :: fpuPowers(:,:)	! Za fuPowers,fvPowers,fwPowers dimenzije su (nglu,nu+1), (nglv,nv+1) i 
	Real*8, Allocatable :: fpvPowers(:,:)	! (nglw,nw+1) jer kolone idu od nule do nu, nv, nw.
	Real*8, Allocatable :: fpwPowers(:,:)	! 1-u1   1+u1   u1^2 -1   u1^3 - u1
											! ...
											! 1-unglu ...
											! Konacno, fp stoji za fprim.
	
	Real*8, Allocatable :: rMatrix(:,:,:,:)				! Matrica r vektora  dimenzija (nglu,nglv,nglw,3) ... r(u,v,w)
	Real*8, Allocatable :: auMatrix(:,:,:,:)			! Matrica au vektora dimenzija (nglu,nglv,nglw,3)
	Real*8, Allocatable :: avMatrix(:,:,:,:)			! Matrica av vektora dimenzija (nglu,nglv,nglw,3)
	Real*8, Allocatable :: awMatrix(:,:,:,:)			! Matrica aw vektora dimenzija (nglu,nglv,nglw,3)
	Real*8, Allocatable :: jacobianMatrix(:,:,:)	! Napomena: za trilinearni element au, av i aw su funkcija samo dve koordinate,
													! dok ce za sve elemente viseg reda to biti funkcija i u i v i w!!!
													! Jacobian je dimenzija (nglu,nglv,nglw).

	Integer*1 iuvwh
	Integer ehOld,eh,ih,jh,kh
	Integer kMat
	Integer*1 face
	Integer ihCon
	Complex*16 cFF(3)

	Complex*16 czero, cone, cj							! Global Constants
	Common /kompleks/ czero, cone, cj					! Global Constants


	cEsc(:) = czero
					  
	ehOld = 0
	Do kMat = 1,matDimDis

		ihCon = Iabs(vectorD(kMat))

		If ( ihCon == 0 ) Then
			Cycle ! kMat
		End If

		! Posto je E = Suma[alpha * Integral],
		! ovde se prolazi samo ako je alpha(e,iUVW, i, j, k) /= 0

		eh		= eiUVWijk(kMat,1)
		iuvwh	= eiUVWijk(kMat,2)
		ih		= eiUVWijk(kMat,3)
		jh		= eiUVWijk(kMat,4)
		kh		= eiUVWijk(kMat,5)

		If ( ehOld /= eh ) Then
			If ( ehOld /= 0 ) Then
				Deallocate ( xglu,xglv,xglw )
				Deallocate ( wglu,wglv,wglw )
				Deallocate ( auMatrix,avMatrix,awMatrix,rMatrix )
				Deallocate ( jacobianMatrix )
				Deallocate (   uPowers,  vPowers,  wPowers )
				Deallocate (  fuPowers, fvPowers, fwPowers )
				Deallocate ( fpuPowers,fpvPowers,fpwPowers )
			End If

			Allocate (xglu(0:nglu(eh)+1), xglv(0:nglv(eh)+1), xglw(0:nglw(eh)+1))	! Popunjavanje tacaka i tezinskih 
			Allocate (wglu(nglu(eh)), wglv(nglv(eh)), wglw(nglw(eh)))	! koeficijenata za GL integraciju
			Call GAUSSK (nglu(eh),xglu,wglu)
			xglu(0)          = -1
			xglu(nglu(eh)+1) =  1
			Call GAUSSK (nglv(eh),xglv,wglv)
			xglv(0)          = -1
			xglv(nglv(eh)+1) =  1
			Call GAUSSK (nglw(eh),xglw,wglw)
			xglw(0)          = -1
			xglw(nglw(eh)+1) =  1
			
			Allocate (  rMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( auMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( avMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( awMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( jacobianMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1) )
			Call UNITARYVECTORS(nglu,nglv,nglw,								&	! Popunjavanje matrice
								xglu,xglv,xglw,								&	! geometrijskih parametara
								eh,numberOfElements,elementOrders,rs,		&	! za tekuci element
								rMatrix,auMatrix,avMatrix,awMatrix,jacobianMatrix)
			
			Allocate (   uPowers(0:nglu(eh)+1,0:nu(eh)),   vPowers(0:nglv(eh)+1,0:nv(eh)),   wPowers(0:nglw(eh)+1,0:nw(eh)) )
			Allocate (  fuPowers(0:nglu(eh)+1,0:nu(eh)),  fvPowers(0:nglv(eh)+1,0:nv(eh)),  fwPowers(0:nglw(eh)+1,0:nw(eh)) )
			Allocate ( fpuPowers(0:nglu(eh)+1,0:nu(eh)), fpvPowers(0:nglv(eh)+1,0:nv(eh)), fpwPowers(0:nglw(eh)+1,0:nw(eh)) )
			Select Case (indicatorBasisType)
			Case (1) ! Kolundzija
				Call FINDPOWERS(nu,nv,nw,						&
								nglu,nglv,nglw,					&
								xglu,xglv,xglw,eh,				&
								uPowers,vPowers,wPowers,		&
								fuPowers,fvPowers,fwPowers,		&
								fpuPowers,fpvPowers,fpwPowers)
			Case (2) ! Legendre
				Call FINDPOWERSLEGENDRE(nu,nv,nw,				&
								nglu,nglv,nglw,					&
								xglu,xglv,xglw,eh,				&
								uPowers,vPowers,wPowers,		&
								fuPowers,fvPowers,fwPowers,		&
								fpuPowers,fpvPowers,fpwPowers)
			Case Default
				Stop 'Unsupported basis function type!'
			End Select
		End If

		ehOld = eh

		Do face = 1,6

			If ( abclist(eh,face) /= 1 ) Then
				Cycle ! face
			End If

			! Ovde se prolazi samo ako je na tekucoj stranici tekuceg elementa primenjen ABC uslov, tj.
			! ako postoji potreba da se racuna integral.

			cFF(:) = czero

			Select Case (iuvwh)
			Case (1) !iuvwh
				Call FINDUFF(ih,jh,kh,									&
							nglu,nglv,nglw,								&
							wglu,wglv,wglw,								&
							eh,numberOfElements,face,					&
							uPowers,fvPowers,fwPowers,					&
							fpvPowers,fpwPowers,						&
							auMatrix,avMatrix,awMatrix,jacobianMatrix,	&
							rMatrix,									&
							k0,iR,										&
							cFF)	! See XIII-6												  
			Case (2) !iuvwh
				Call FINDVFF(ih,jh,kh,									&
							nglu,nglv,nglw,								&
							wglu,wglv,wglw,								&
							eh,numberOfElements,face,					&
							fuPowers,vPowers,fwPowers,					&
							fpuPowers,fpwPowers,						&
							auMatrix,avMatrix,awMatrix,jacobianMatrix,	&
							rMatrix,									&
							k0,iR,										&
							cFF)	! See XIII-6
			Case (3) ! iuvwh 
				Call FINDWFF(ih,jh,kh,									&
							nglu,nglv,nglw,								&
							wglu,wglv,wglw,								&
							eh,numberOfElements,face,					&
							fuPowers,fvPowers,wPowers,					&
							fpuPowers,fpvPowers,						&
							auMatrix,avMatrix,awMatrix,jacobianMatrix,	&
							rMatrix,									&
							k0,iR,										&
							cFF)	! See XIII-6
			End Select !iuvwh
			
			If ( vectorD(kMat) > 0 ) Then
				cEsc(:) = cEsc(:) + cAlpha(ihCon)*cFF(:)
			Else
				cEsc(:) = cEsc(:) - cAlpha(ihCon)*cFF(:)
			End If

		End Do ! face

	End Do !kMat

	Deallocate ( xglu,xglv,xglw )
	Deallocate ( wglu,wglv,wglw )
	Deallocate ( auMatrix,avMatrix,awMatrix )
	Deallocate ( jacobianMatrix )
	Deallocate (   uPowers,  vPowers,  wPowers )
	Deallocate (  fuPowers, fvPowers, fwPowers )
	Deallocate ( fpuPowers,fpvPowers,fpwPowers )
	Deallocate ( rMatrix )

Return
End	! FINDESC

!*************************************************************************************

Subroutine FINDESCrwg(indicatorBasisType,								 &
					numberOfElements,elementOrders,						 & ! Racuna E scattered
					numberOfPorts,portType,wgs1List,wgs2List,wgsuList,	 & ! za rectangular waveguide i
					numberOfNodes,nodeGlobalCoord,waveguideSi,aRWG,bRWG, & ! pobudu u obliku TE10 talasa
					rs,nu,nv,nw,										 & 
			 		nglu,nglv,nglw,										 &
					matDimDis,matDimCon,eiUVWijk,vectorD,cAlpha,		 &
					cE0,kz10,											 &
					cSparRWG,powerCheck) 

	Integer*1 indicatorBasisType
	Integer numberOfElements, numberOfPorts, numberOfNodes
	Integer*1 wgsuList(numberOfElements,6),portType(numberOfPorts)
	Integer wgs1List(numberOfElements,6),wgs2List(numberOfElements,6),waveGuideSi(numberOfPorts,3)
	Real*8    nodeGlobalCoord(numberOfNodes,3)
	Real*8	  aRWG(numberOfPorts,4),bRWG(numberOfPorts,4)	! Duzina 'a' za rectangular waveguide.
	Integer*1 elementOrders(numberOfElements)
	Integer matDimDis,matDimCon,vectorD(matDimDis)
	Complex*16 cAlpha(matDimCon)
	Integer eiUVWijk(matDimDis,5)
	Real*8    kz10
	Complex*16 cE0
	Complex*16 cSparRWG(numberOfPorts)
	Real*8     powerCheck

	Integer nu(numberOfElements), nv(numberOfElements), nw(numberOfElements)
	Integer nglu(numberOfElements), nglv(numberOfElements), nglw(numberOfElements)
	Real*8    rs(numberOfElements,125,3)
	Real*8, Allocatable :: xglu(:), wglu(:)	! GL Int points and weights (nglu(element)) 
	Real*8, Allocatable :: xglv(:), wglv(:)	! GL Int points and weights (nglv(element))
	Real*8, Allocatable :: xglw(:), wglw(:)	! GL Int points and weights (nglw(element))
	Real*8, Allocatable :: uPowers(:,:)		! Matrice dimenzija (nglu,nu+1),(nglv,nv+1),(nglw,nw+1) sa stepenima koordinata
	Real*8, Allocatable :: vPowers(:,:)		! u^i, v^j i w^k u tackama odredjenim gausovom podelom za integraciju.
	Real*8, Allocatable :: wPowers(:,:)		! 		0	1	  2	   3		  nu
	Real*8, Allocatable :: fuPowers(:,:)	!   1	1	u1  u1^2  u1^3  ...  u1^nu
	Real*8, Allocatable :: fvPowers(:,:)	!  ...
	Real*8, Allocatable :: fwPowers(:,:)	! nglu  1	unglu ...            unglu^nu
	Real*8, Allocatable :: fpuPowers(:,:)	! Za fuPowers,fvPowers,fwPowers dimenzije su (nglu,nu+1), (nglv,nv+1) i 
	Real*8, Allocatable :: fpvPowers(:,:)	! (nglw,nw+1) jer kolone idu od nule do nu, nv, nw.
	Real*8, Allocatable :: fpwPowers(:,:)	! 1-u1   1+u1   u1^2 -1   u1^3 - u1
											! ...
											! 1-unglu ...
											! Konacno, fp stoji za fprim.
	
	Real*8, Allocatable :: rMatrix(:,:,:,:)				! Matrica r vektora  dimenzija (nglu,nglv,nglw,3) ... r(u,v,w)
	Real*8, Allocatable :: auMatrix(:,:,:,:)			! Matrica au vektora dimenzija (nglu,nglv,nglw,3)
	Real*8, Allocatable :: avMatrix(:,:,:,:)			! Matrica av vektora dimenzija (nglu,nglv,nglw,3)
	Real*8, Allocatable :: awMatrix(:,:,:,:)			! Matrica aw vektora dimenzija (nglu,nglv,nglw,3)
	Real*8, Allocatable :: jacobianMatrix(:,:,:)	! Napomena: za trilinearni element au, av i aw su funkcija samo dve koordinate,
													! dok ce za sve elemente viseg reda to biti funkcija i u i v i w!!!
													! Jacobian je dimenzija (nglu,nglv,nglw).

	Integer*1 iuvwh
	Integer ehOld,eh,ih,jh,kh
	Integer kMat
	Integer*1 face
	Integer ihCon
	Integer portNo
	Real*8	  a,b,ixprim(3),iyprim(3)
	Complex*16 cFF

	Complex*16 czero, cone, cj							! Global Constants
	Common /kompleks/ czero, cone, cj					! Global Constants


	cSparRWG(:) = czero
					  
	ehOld = 0
	Do kMat = 1,matDimDis

		ihCon = Iabs(vectorD(kMat))

		If ( ihCon == 0 ) Then
			Cycle ! kMat
		End If

		! Posto je E = Suma[alpha * Integral],
		! ovde se prolazi samo ako je alpha(e,iUVW, i, j, k) /= 0

		eh		= eiUVWijk(kMat,1)
		iuvwh	= eiUVWijk(kMat,2)
		ih		= eiUVWijk(kMat,3)
		jh		= eiUVWijk(kMat,4)
		kh		= eiUVWijk(kMat,5)

		If ( ehOld /= eh ) Then
			If ( ehOld /= 0 ) Then
				Deallocate ( xglu,xglv,xglw )
				Deallocate ( wglu,wglv,wglw )
				Deallocate ( auMatrix,avMatrix,awMatrix,rMatrix )
				Deallocate ( jacobianMatrix )
				Deallocate (   uPowers,  vPowers,  wPowers )
				Deallocate (  fuPowers, fvPowers, fwPowers )
				Deallocate ( fpuPowers,fpvPowers,fpwPowers )
			End If

			Allocate (xglu(0:nglu(eh)+1), xglv(0:nglv(eh)+1), xglw(0:nglw(eh)+1))	! Popunjavanje tacaka i tezinskih 
			Allocate (wglu(nglu(eh)), wglv(nglv(eh)), wglw(nglw(eh)))	! koeficijenata za GL integraciju
			Call GAUSSK (nglu(eh),xglu,wglu)
			xglu(0)          = -1
			xglu(nglu(eh)+1) =  1
			Call GAUSSK (nglv(eh),xglv,wglv)
			xglv(0)          = -1
			xglv(nglv(eh)+1) =  1
			Call GAUSSK (nglw(eh),xglw,wglw)
			xglw(0)          = -1
			xglw(nglw(eh)+1) =  1
			
			Allocate (  rMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( auMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( avMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( awMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( jacobianMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1) )
			Call UNITARYVECTORS(nglu,nglv,nglw,								&	! Popunjavanje matrice
								xglu,xglv,xglw,								&	! geometrijskih parametara
								eh,numberOfElements,elementOrders,rs,		&	! za tekuci element
								rMatrix,auMatrix,avMatrix,awMatrix,jacobianMatrix)
			
			Allocate (   uPowers(0:nglu(eh)+1,0:nu(eh)),   vPowers(0:nglv(eh)+1,0:nv(eh)),   wPowers(0:nglw(eh)+1,0:nw(eh)) )
			Allocate (  fuPowers(0:nglu(eh)+1,0:nu(eh)),  fvPowers(0:nglv(eh)+1,0:nv(eh)),  fwPowers(0:nglw(eh)+1,0:nw(eh)) )
			Allocate ( fpuPowers(0:nglu(eh)+1,0:nu(eh)), fpvPowers(0:nglv(eh)+1,0:nv(eh)), fpwPowers(0:nglw(eh)+1,0:nw(eh)) )
			Select Case (indicatorBasisType)
			Case (1) ! Kolundzija
				Call FINDPOWERS(nu,nv,nw,						&
								nglu,nglv,nglw,					&
								xglu,xglv,xglw,eh,				&
								uPowers,vPowers,wPowers,		&
								fuPowers,fvPowers,fwPowers,		&
								fpuPowers,fpvPowers,fpwPowers)
			Case (2) ! Legendre
				Call FINDPOWERSLEGENDRE(nu,nv,nw,				&
								nglu,nglv,nglw,					&
								xglu,xglv,xglw,eh,				&
								uPowers,vPowers,wPowers,		&
								fuPowers,fvPowers,fwPowers,		&
								fpuPowers,fpvPowers,fpwPowers)
			Case Default
				Stop 'Unsupported basis function type!'
			End Select
		End If

		ehOld = eh

		Do face = 1,6

			If ( wgsuList(eh,face) /= 1 ) Then
				Cycle ! face
			End If

			! Ovde se prolazi samo ako je na tekucoj stranici tekuceg elementa primenjen Reflection ili Transmission uslov,
			! tj. ako postoji potreba da se racuna integral za Sii ili Sij.
			! Posto je u nastavku wgsuList(eh,face) = 1, znaci da je wgs1List(eh,face) /= 0 ili wgs1List(eh,face) /= 0,
			! pri cemu ne mogu oba istovremeno jer stranica pripada ili refl portu, ili transm portu (ne mogu oba).

			cFF = czero

			If ( wgs1List(eh,face) /= 0 ) Then								! Algoritam za Refleksiju
				
				portNo = wgs1List(eh,face)
				a      = aRWG(portNo,4)
				b      = bRWG(portNo,4)
				ixprim = aRWG(portNo,1:3)
				iyprim = bRWG(portNo,1:3)

				Select Case (iuvwh)
				Case (1) !iuvwh
					Call FINDURTrwg(ih,jh,kh,												&
								nglu,nglv,nglw,												&
								wglu,wglv,wglw,												&
								eh,numberOfElements,face,									&
								uPowers,fvPowers,fwPowers,									&
								auMatrix,avMatrix,awMatrix,jacobianMatrix,					&
								rMatrix,													&
								nodeGlobalCoord(waveguideSi(portNo,1),:),a,ixprim,iyprim,	& ! s1point,a,ixprim,iyprim
								cFF)	! See XIII-6												  
				Case (2) !iuvwh
					Call FINDVRTrwg(ih,jh,kh,												&
								nglu,nglv,nglw,												&
								wglu,wglv,wglw,												&
								eh,numberOfElements,face,									&
								fuPowers,vPowers,fwPowers,									&
								auMatrix,avMatrix,awMatrix,jacobianMatrix,					&
								rMatrix,													&
								nodeGlobalCoord(waveguideSi(portNo,1),:),a,ixprim,iyprim,	& ! s1point,a,ixprim,iyprim								
								cFF)	! See XIII-6
				Case (3) ! iuvwh 
					Call FINDWRTrwg(ih,jh,kh,												&
								nglu,nglv,nglw,												&
								wglu,wglv,wglw,												&
								eh,numberOfElements,face,									&
								fuPowers,fvPowers,wPowers,									&
								auMatrix,avMatrix,awMatrix,jacobianMatrix,					&
								rMatrix,													&
								nodeGlobalCoord(waveguideSi(portNo,1),:),a,ixprim,iyprim,	& ! s1point,a,ixprim,iyprim
								cFF)	! See XIII-6
				End Select !iuvwh

				If ( vectorD(kMat) > 0 ) Then
					cSparRWG(wgs1List(eh,face)) = cSparRWG(wgs1List(eh,face)) + cAlpha(ihCon)*cFF
				Else
					cSparRWG(wgs1List(eh,face)) = cSparRWG(wgs1List(eh,face)) - cAlpha(ihCon)*cFF
				End If

			Else															! Algoritam za Transmisiju

				portNo = wgs2List(eh,face)
				a      = aRWG(portNo,4)
				b      = bRWG(portNo,4)
				ixprim = aRWG(portNo,1:3)
				iyprim = bRWG(portNo,1:3)

				Select Case (iuvwh)
				Case (1) !iuvwh
					Call FINDURTrwg(ih,jh,kh,												&
								nglu,nglv,nglw,												&
								wglu,wglv,wglw,												&
								eh,numberOfElements,face,									&
								uPowers,fvPowers,fwPowers,									&
								auMatrix,avMatrix,awMatrix,jacobianMatrix,					&
								rMatrix,													&
								nodeGlobalCoord(waveguideSi(portNo,1),:),a,ixprim,iyprim,	& ! s1point,a,ixprim,iyprim
								cFF)	! See XIII-6												  
				Case (2) !iuvwh
					Call FINDVRTrwg(ih,jh,kh,												&
								nglu,nglv,nglw,												&
								wglu,wglv,wglw,												&
								eh,numberOfElements,face,									&
								fuPowers,vPowers,fwPowers,									&
								auMatrix,avMatrix,awMatrix,jacobianMatrix,					&
								rMatrix,													&
								nodeGlobalCoord(waveguideSi(portNo,1),:),a,ixprim,iyprim,	& ! s1point,a,ixprim,iyprim
								cFF)	! See XIII-6
				Case (3) ! iuvwh 
					Call FINDWRTrwg(ih,jh,kh,												&
								nglu,nglv,nglw,												&
								wglu,wglv,wglw,												&
								eh,numberOfElements,face,									&
								fuPowers,fvPowers,wPowers,									&
								auMatrix,avMatrix,awMatrix,jacobianMatrix,					&
								rMatrix,													&
								nodeGlobalCoord(waveguideSi(portNo,1),:),a,ixprim,iyprim,	& ! s1point,a,ixprim,iyprim
								cFF)	! See XIII-6
				End Select !iuvwh

				If ( vectorD(kMat) > 0 ) Then
					cSparRWG(wgs2List(eh,face)) = cSparRWG(wgs2List(eh,face)) + cAlpha(ihCon)*cFF
				Else
					cSparRWG(wgs2List(eh,face)) = cSparRWG(wgs2List(eh,face)) - cAlpha(ihCon)*cFF
				End If

			EndIf ! reflection/transmission
			
		End Do ! face

	End Do !kMat

	powerCheck = 0.d0

	Do portNo = 1,numberOfPorts
		SelectCase (portType(portNo))
		Case(1)	
			cSparRWG(portNo) = cSparRWG(portNo) * 2.d0/(a*b*cE0) - 1.d0
		Case(2)
			cSparRWG(portNo) = cSparRWG(portNo) * 2.d0/(a*b*cE0)! * CDexp(cj*kz10*10.d0)	! To Do ...
		EndSelect
		powerCheck = powerCheck + CDAbs(cSparRWG(portNo))*CDAbs(cSparRWG(portNo))
	End Do ! portNo

	Deallocate ( xglu,xglv,xglw )
	Deallocate ( wglu,wglv,wglw )
	Deallocate ( auMatrix,avMatrix,awMatrix )
	Deallocate ( jacobianMatrix )
	Deallocate (   uPowers,  vPowers,  wPowers )
	Deallocate (  fuPowers, fvPowers, fwPowers )
	Deallocate ( fpuPowers,fpvPowers,fpwPowers )
	Deallocate ( rMatrix )

Return
End	! FINDESCrwg

!*************************************************************************************

Subroutine FINDESCMODE(indicatorBasisType,indicatorBasisType2D,				&
					numberOfElements,elementOrders,							& ! Racuna E scattered
					numberOfPorts,portType,wgs1List,wgs2List,wgsuList,		& ! za arbitrary waveguide i
					numberOfNodes,nodeGlobalCoord,							& ! pobudu u obliku moda talasa
					rs,nu,nv,nw,											& 
			 		nglu,nglv,nglw,											&
					matDimDis,matDimCon,eiUVWijk,vectorD,cAlpha,			&
					rs2D,nu2D,nv2D,											&
					nglu2D,nglv2D,											&
					numberOfElements2D,elementOrders2D,						&
					muRelative2D,epsilonRelative2D,							&
					matDimDis2D,matDimCon2D,eiUVWijk2D,vectorD2D,cAlpha2D,	&
					cE0,cGamma2D,											&
					cSparRWG,powerCheck) 

	!*** 3D Transferred variables
	Integer*1 indicatorBasisType, indicatorBasisType2D
	Integer numberOfElements, numberOfPorts, numberOfNodes
	Integer*1 wgsuList(numberOfElements,6),portType(numberOfPorts)
	Integer wgs1List(numberOfElements,6),wgs2List(numberOfElements,6)
	Real*8    nodeGlobalCoord(numberOfNodes,3)
	Integer*1 elementOrders(numberOfElements)
	Integer matDimDis,matDimCon,vectorD(matDimDis)
	Complex*16 cAlpha(matDimCon)
	Integer eiUVWijk(matDimDis,5)
	Complex*16 cE0,cGamma2D
	Complex*16 cSparRWG(numberOfPorts)
	Real*8     powerCheck

	Integer nu(numberOfElements), nv(numberOfElements), nw(numberOfElements)
	Integer nglu(numberOfElements), nglv(numberOfElements), nglw(numberOfElements)
	Real*8    rs(numberOfElements,125,3)

	!*** 2D Transferred variables
	Integer numberOfElements2D
	Integer*1 elementOrders2D(numberOfElements2D)
	Integer nu2D(numberOfElements2D), nv2D(numberOfElements2D)
	Integer nglu2D(numberOfElements2D), nglv2D(numberOfElements2D)
	Real*8    rs2D(numberOfElements2D,25,3)

	Real*8, Dimension(numberOfElements2D,2) :: muRelative2D, epsilonRelative2D
	Integer matDimDis2D,matDimCon2D,vectorD2D(matDimDis2D)
	Integer eiUVWijk2D(matDimDis2D,4)
	Complex*16 cAlpha2D(matDimCon2D)


	!*** 3D Local variables
	Real*8, Allocatable :: xglu(:), wglu(:)	! GL Int points and weights (nglu(element)) 
	Real*8, Allocatable :: xglv(:), wglv(:)	! GL Int points and weights (nglv(element))
	Real*8, Allocatable :: xglw(:), wglw(:)	! GL Int points and weights (nglw(element))
	Real*8, Allocatable :: uPowers(:,:)		! Matrice dimenzija (nglu,nu+1),(nglv,nv+1),(nglw,nw+1) sa stepenima koordinata
	Real*8, Allocatable :: vPowers(:,:)		! u^i, v^j i w^k u tackama odredjenim gausovom podelom za integraciju.
	Real*8, Allocatable :: wPowers(:,:)		! 		0	1	  2	   3		  nu
	Real*8, Allocatable :: fuPowers(:,:)	!   1	1	u1  u1^2  u1^3  ...  u1^nu
	Real*8, Allocatable :: fvPowers(:,:)	!  ...
	Real*8, Allocatable :: fwPowers(:,:)	! nglu  1	unglu ...            unglu^nu
	Real*8, Allocatable :: fpuPowers(:,:)	! Za fuPowers,fvPowers,fwPowers dimenzije su (nglu,nu+1), (nglv,nv+1) i 
	Real*8, Allocatable :: fpvPowers(:,:)	! (nglw,nw+1) jer kolone idu od nule do nu, nv, nw.
	Real*8, Allocatable :: fpwPowers(:,:)	! 1-u1   1+u1   u1^2 -1   u1^3 - u1
	
	Real*8, Allocatable :: rMatrix(:,:,:,:)				! Matrica r vektora  dimenzija (nglu,nglv,nglw,3) ... r(u,v,w)
	Real*8, Allocatable :: auMatrix(:,:,:,:)			! Matrica au vektora dimenzija (nglu,nglv,nglw,3)
	Real*8, Allocatable :: avMatrix(:,:,:,:)			! Matrica av vektora dimenzija (nglu,nglv,nglw,3)
	Real*8, Allocatable :: awMatrix(:,:,:,:)			! Matrica aw vektora dimenzija (nglu,nglv,nglw,3)
	Real*8, Allocatable :: jacobianMatrix(:,:,:)	! Napomena: za trilinearni element au, av i aw su funkcija samo dve koordinate,
													! dok ce za sve elemente viseg reda to biti funkcija i u i v i w!!!
													! Jacobian je dimenzija (nglu,nglv,nglw).

	Integer*1 iuvwh
	Integer ehOld,eh,ih,jh,kh
	Integer kMat
	Integer*1 face
	Integer ihCon
	Integer portNo
	Complex*16 cFF

	!*** 2D Local variables
	Complex*16, Allocatable :: cEmt(:,:,:)
	Real*8 AmSq

	!*** Common variables
	Complex*16 czero, cone, cj							! Global Constants
	Common /kompleks/ czero, cone, cj					! Global Constants

	Call FINDMODENORMSQ(indicatorBasisType2D,										&
						rs2D,nu2D,nv2D,												&	! Calculates Am^2 for the given mode
					 	nglu2D,nglv2D,												&	! See XVII - 11
						numberOfElements2D,elementOrders2D,							&
						muRelative2D,epsilonRelative2D,								&
						matDimDis2D,matDimCon2D,eiUVWijk2D,vectorD2D,cAlpha2D,AmSq)

	cSparRWG(:) = czero
					  
	ehOld = 0
	Do kMat = 1,matDimDis

		ihCon = Iabs(vectorD(kMat))

		If ( ihCon == 0 ) Then
			Cycle ! kMat
		End If

		! Posto je E = Suma[alpha * Integral],
		! ovde se prolazi samo ako je alpha(e,iUVW, i, j, k) /= 0

		eh		= eiUVWijk(kMat,1)
		iuvwh	= eiUVWijk(kMat,2)
		ih		= eiUVWijk(kMat,3)
		jh		= eiUVWijk(kMat,4)
		kh		= eiUVWijk(kMat,5)

		If ( ehOld /= eh ) Then
			If ( ehOld /= 0 ) Then
				Deallocate ( xglu,xglv,xglw )
				Deallocate ( wglu,wglv,wglw )
				Deallocate ( auMatrix,avMatrix,awMatrix,rMatrix )
				Deallocate ( jacobianMatrix )
				Deallocate (   uPowers,  vPowers,  wPowers )
				Deallocate (  fuPowers, fvPowers, fwPowers )
				Deallocate ( fpuPowers,fpvPowers,fpwPowers )
				If ( ehOld <= numberOfElements2D ) Then
					Deallocate ( cEmt )
				End If
			End If

			Allocate (xglu(0:nglu(eh)+1), xglv(0:nglv(eh)+1), xglw(0:nglw(eh)+1))	! Popunjavanje tacaka i tezinskih 
			Allocate (wglu(nglu(eh)), wglv(nglv(eh)), wglw(nglw(eh)))	! koeficijenata za GL integraciju
			Call GAUSSK (nglu(eh),xglu,wglu)
			xglu(0)          = -1
			xglu(nglu(eh)+1) =  1
			Call GAUSSK (nglv(eh),xglv,wglv)
			xglv(0)          = -1
			xglv(nglv(eh)+1) =  1
			Call GAUSSK (nglw(eh),xglw,wglw)
			xglw(0)          = -1
			xglw(nglw(eh)+1) =  1
			
			Allocate (  rMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( auMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( avMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( awMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1,3) )
			Allocate ( jacobianMatrix(0:nglu(eh)+1,0:nglv(eh)+1,0:nglw(eh)+1) )
			Call UNITARYVECTORS(nglu,nglv,nglw,								&	! Popunjavanje matrice
								xglu,xglv,xglw,								&	! geometrijskih parametara
								eh,numberOfElements,elementOrders,rs,		&	! za tekuci element
								rMatrix,auMatrix,avMatrix,awMatrix,jacobianMatrix)
			
			Allocate (   uPowers(0:nglu(eh)+1,0:nu(eh)),   vPowers(0:nglv(eh)+1,0:nv(eh)),   wPowers(0:nglw(eh)+1,0:nw(eh)) )
			Allocate (  fuPowers(0:nglu(eh)+1,0:nu(eh)),  fvPowers(0:nglv(eh)+1,0:nv(eh)),  fwPowers(0:nglw(eh)+1,0:nw(eh)) )
			Allocate ( fpuPowers(0:nglu(eh)+1,0:nu(eh)), fpvPowers(0:nglv(eh)+1,0:nv(eh)), fpwPowers(0:nglw(eh)+1,0:nw(eh)) )
			Select Case (indicatorBasisType)
			Case (1) ! Kolundzija
				Call FINDPOWERS(nu,nv,nw,						&
								nglu,nglv,nglw,					&
								xglu,xglv,xglw,eh,				&
								uPowers,vPowers,wPowers,		&
								fuPowers,fvPowers,fwPowers,		&
								fpuPowers,fpvPowers,fpwPowers)
			Case (2) ! Legendre
				Call FINDPOWERSLEGENDRE(nu,nv,nw,				&
								nglu,nglv,nglw,					&
								xglu,xglv,xglw,eh,				&
								uPowers,vPowers,wPowers,		&
								fuPowers,fvPowers,fwPowers,		&
								fpuPowers,fpvPowers,fpwPowers)
			Case Default
				Stop 'Unsupported basis function type!'
			End Select

			If ( eh <= numberOfElements2D ) Then
				Allocate ( cEmt(0:nglu2D(eh)+1,0:nglv2D(eh)+1,3) )
				cEmt(:,:,:) = czero
			End If
		End If

		If ( eh <= numberOfElements2D ) Then
			Call FINDEMODET2D(indicatorBasisType2D,										&
							eh,															&	! Tabulates vector emt
							rs2D,nu2D,nv2D,												&	! on the element eh.
						 	nglu2D,nglv2D,												&	! See XVII - 8
							numberOfElements2D,elementOrders2D,							&
							muRelative2D,epsilonRelative2D,								&
							matDimDis2D,matDimCon2D,eiUVWijk2D,vectorD2D,cAlpha2D,AmSq,cEmt)
		End If

		ehOld = eh

		Do face = 1,6

			If ( wgsuList(eh,face) /= 1 ) Then
				Cycle ! face
			End If

			! Ovde se prolazi samo ako je na tekucoj stranici tekuceg elementa primenjen Reflection ili Transmission uslov,
			! tj. ako postoji potreba da se racuna integral za Sii ili Sij.
			! Posto je u nastavku wgsuList(eh,face) = 1, znaci da je wgs1List(eh,face) /= 0 ili wgs1List(eh,face) /= 0,
			! pri cemu ne mogu oba istovremeno jer stranica pripada ili refl portu, ili transm portu (ne mogu oba).

			cFF = czero

			If ( wgs1List(eh,face) /= 0 ) Then								! Algoritam za Refleksiju
				
				Select Case (iuvwh)
				Case (1) !iuvwh
					Call FINDUGMODE(ih,jh,kh,										&
									nglu,nglv,nglw,									&
									wglu,wglv,wglw,									&
									eh,numberOfElements,face,						&
									uPowers,fvPowers,fwPowers,						&
									auMatrix,avMatrix,awMatrix,jacobianMatrix,		&
									nglu2D,nglv2D,									&
									cEmt,cFF)	! See XVII-10
				Case (2) !iuvwh
					Call FINDVGMODE(ih,jh,kh,										&
									nglu,nglv,nglw,									&
									wglu,wglv,wglw,									&
									eh,numberOfElements,face,						&
									fuPowers,vPowers,fwPowers,						&
									auMatrix,avMatrix,awMatrix,jacobianMatrix,		&
									nglu2D,nglv2D,									&
									cEmt,cFF)	! See XVII-10

				Case (3) ! iuvwh 
					Call FINDWGMODE(ih,jh,kh,										&
									nglu,nglv,nglw,									&
									wglu,wglv,wglw,									&
									eh,numberOfElements,face,						&
									fuPowers,fvPowers,wPowers,						&
									auMatrix,avMatrix,awMatrix,jacobianMatrix,		&
									nglu2D,nglv2D,									&
									cEmt,cFF)	! See XVII-10
				End Select ! iuvwh

				If ( vectorD(kMat) > 0 ) Then
					cSparRWG(wgs1List(eh,face)) = cSparRWG(wgs1List(eh,face)) + cAlpha(ihCon)*cFF
				Else
					cSparRWG(wgs1List(eh,face)) = cSparRWG(wgs1List(eh,face)) - cAlpha(ihCon)*cFF
				End If

			Else															! Algoritam za Transmisiju
				! To Do ...
			EndIf ! reflection/transmission
			
		End Do ! face

	End Do !kMat

	powerCheck = 0.d0

	Do portNo = 1,numberOfPorts
		SelectCase (portType(portNo))
		Case(3)	
			cSparRWG(portNo) = cSparRWG(portNo) - 1.d0 !  / AmSq
		Case(4)
			! To Do ...
		Case Default
			Stop '... Wrong port type!'
		EndSelect
		powerCheck = powerCheck + CDAbs(cSparRWG(portNo))*CDAbs(cSparRWG(portNo))
	End Do ! portNo

	Deallocate ( xglu,xglv,xglw )
	Deallocate ( wglu,wglv,wglw )
	Deallocate ( auMatrix,avMatrix,awMatrix )
	Deallocate ( jacobianMatrix )
	Deallocate (   uPowers,  vPowers,  wPowers )
	Deallocate (  fuPowers, fvPowers, fwPowers )
	Deallocate ( fpuPowers,fpvPowers,fpwPowers )
	Deallocate ( rMatrix )

Return
End	! FINDESCMODE

!*************************************************************************************