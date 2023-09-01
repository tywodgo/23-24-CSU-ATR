//////////////////// CSUATR Arduino Code ////////////////////
// Current thoughts:
// Still need to implement limit switches

//////////////////// Serial Parameters ////////////////////
char delimiter = '>';
int const bufferLength = 100; // make this longer
char inputBuffer[bufferLength];
int inputLength = 0;
bool receiving = false;

char outputBuffer[bufferLength];

//////////////////// Motor Parameters ////////////////////
String returnStringSuccess = " ";
String returnStringFailed = " ";

bool inMotion = false;
bool queued = false;
char currentMotor = ' ';
int currentDirection = 1; // 1 or -1
unsigned long startTime = 0;
unsigned long stopTime = 0;

// Scalars for duty cycle
int dutyCycleP = 125; // from 0 to 255
int dutyCycleV = 125;
int dutyCycleH = 125;
int dutyCycleD = 125;
int dutyCycleA = 125;
int dutyCycleE = 125;

// Scalars for time calulation
float timeScalarP = 0.02222; // polarization untested
float timeScalarV = 0.12853;
float timeScalarH = 0.77768;
float timeScalarD = 1.14531;
float timeScalarA = 0.08128;
float timeScalarE = 0.02222; // elevation needs work

// Motor Positive Direction (allows user to switch the direction indicated as 'positive')
int posDirP = 1;  // 1 -> normal direction
int posDirV = 1;  // -1 -> reversed direction
int posDirH = 1;
int posDirD = 1;
int posDirA = 1;
int posDirE = 1;


//////////////////// Pins ////////////////////
// Enable
const int PIN_ENABLE_MOTORS = 50;
// Direction
const int PIN_DIR_MOTOR_P = 37;
const int PIN_DIR_MOTOR_V = 39;
const int PIN_DIR_MOTOR_H = 41;
const int PIN_DIR_MOTOR_D = 43;
const int PIN_DIR_MOTOR_A = 45;
const int PIN_DIR_MOTOR_E = 47;
// Step
const int PIN_STEP_MOTOR_P = 9;
const int PIN_STEP_MOTOR_V = 2;
const int PIN_STEP_MOTOR_H = 3;
const int PIN_STEP_MOTOR_D = 6;
const int PIN_STEP_MOTOR_A = 7;
const int PIN_STEP_MOTOR_E = 10;
// Limit Switches
//const int PIN_LIMIT_P = 0;
//const int PIN_LIMIT_V = 0;
//const int PIN_LIMIT_H = 0;
//const int PIN_LIMIT_D = 0;
//const int PIN_LIMIT_A = 0;
//const int PIN_LIMIT_E = 0;

//////////////////// Constructor ////////////////////
void setup()
{
  Serial.begin(9600); // This baud rate should be the same as the CSUATR Program

  setPWMFrequency();
  
  pinMode(PIN_ENABLE_MOTORS, OUTPUT);
  
  pinMode(PIN_DIR_MOTOR_P, OUTPUT);
  pinMode(PIN_DIR_MOTOR_V, OUTPUT);
  pinMode(PIN_DIR_MOTOR_H, OUTPUT);
  pinMode(PIN_DIR_MOTOR_D, OUTPUT);
  pinMode(PIN_DIR_MOTOR_A, OUTPUT);
  pinMode(PIN_DIR_MOTOR_E, OUTPUT);
  
  pinMode(PIN_STEP_MOTOR_P, OUTPUT);
  pinMode(PIN_STEP_MOTOR_V, OUTPUT);
  pinMode(PIN_STEP_MOTOR_H, OUTPUT);
  pinMode(PIN_STEP_MOTOR_D, OUTPUT);
  pinMode(PIN_STEP_MOTOR_A, OUTPUT);
  pinMode(PIN_STEP_MOTOR_E, OUTPUT);
  
//  pinMode(PIN_LIMIT_P, INPUT);
//  pinMode(PIN_LIMIT_V, INPUT);
//  pinMode(PIN_LIMIT_H, INPUT);
//  pinMode(PIN_LIMIT_D, INPUT);
//  pinMode(PIN_LIMIT_A, INPUT);
//  pinMode(PIN_LIMIT_E, INPUT);

  stopMotors();
  enableMotors();
  enableTimerInterrupts();
}

// This loop function will likely not be used
// Loop function must remain in order to compile properly
void loop(){}

//////////////////// Interrupts ////////////////////
void setPWMFrequency()
{
  //---------------------------------------------- Set PWM frequency for D11 & D12 -----------------------------
//  TCCR1B = TCCR1B & B11111000 | B00000001;    // set timer 1 divisor to     1 for PWM frequency of 31372.55 Hz
//  TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
//  TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz
//  TCCR1B = TCCR1B & B11111000 | B00000100;    // set timer 1 divisor to   256 for PWM frequency of   122.55 Hz
//  TCCR1B = TCCR1B & B11111000 | B00000101;    // set timer 1 divisor to  1024 for PWM frequency of    30.64 Hz

  //---------------------------------------------- Set PWM frequency for D9 & D10 ------------------------------
//  TCCR2B = TCCR2B & B11111000 | B00000001;    // set timer 2 divisor to     1 for PWM frequency of 31372.55 Hz
//  TCCR2B = TCCR2B & B11111000 | B00000010;    // set timer 2 divisor to     8 for PWM frequency of  3921.16 Hz
//  TCCR2B = TCCR2B & B11111000 | B00000011;    // set timer 2 divisor to    32 for PWM frequency of   980.39 Hz
//  TCCR2B = TCCR2B & B11111000 | B00000100;    // set timer 2 divisor to    64 for PWM frequency of   490.20 Hz
//  TCCR2B = TCCR2B & B11111000 | B00000101;    // set timer 2 divisor to   128 for PWM frequency of   245.10 Hz
//  TCCR2B = TCCR2B & B11111000 | B00000110;    // set timer 2 divisor to   256 for PWM frequency of   122.55 Hz
  TCCR2B = TCCR2B & B11111000 | B00000111;    // set timer 2 divisor to  1024 for PWM frequency of    30.64 Hz

	//---------------------------------------------- Set PWM frequency for D2, D3 & D5 ---------------------------
//	TCCR3B = TCCR3B & B11111000 | B00000001;    // set timer 3 divisor to     1 for PWM frequency of 31372.55 Hz
//	TCCR3B = TCCR3B & B11111000 | B00000010;    // set timer 3 divisor to     8 for PWM frequency of  3921.16 Hz
	TCCR3B = TCCR3B & B11111000 | B00000011;    // set timer 3 divisor to    64 for PWM frequency of   490.20 Hz
//	TCCR3B = TCCR3B & B11111000 | B00000100;    // set timer 3 divisor to   256 for PWM frequency of   122.55 Hz
//	TCCR3B = TCCR3B & B11111000 | B00000101;    // set timer 3 divisor to  1024 for PWM frequency of    30.64 Hz

	//---------------------------------------------- Set PWM frequency for D6, D7 & D8 ---------------------------
//	TCCR4B = TCCR4B & B11111000 | B00000001;    // set timer 4 divisor to     1 for PWM frequency of 31372.55 Hz
//	TCCR4B = TCCR4B & B11111000 | B00000010;    // set timer 4 divisor to     8 for PWM frequency of  3921.16 Hz
	TCCR4B = TCCR4B & B11111000 | B00000011;    // set timer 4 divisor to    64 for PWM frequency of   490.20 Hz
//	TCCR4B = TCCR4B & B11111000 | B00000100;    // set timer 4 divisor to   256 for PWM frequency of   122.55 Hz
//	TCCR4B = TCCR4B & B11111000 | B00000101;    // set timer 4 divisor to  1024 for PWM frequency of    30.64 Hz

  //---------------------------------------------- Set PWM frequency for D44, D45 & D46 ------------------------
//  TCCR5B = TCCR5B & B11111000 | B00000001;    // set timer 5 divisor to     1 for PWM frequency of 31372.55 Hz
//  TCCR5B = TCCR5B & B11111000 | B00000010;    // set timer 5 divisor to     8 for PWM frequency of  3921.16 Hz
//  TCCR5B = TCCR5B & B11111000 | B00000011;    // set timer 5 divisor to    64 for PWM frequency of   490.20 Hz
//  TCCR5B = TCCR5B & B11111000 | B00000100;    // set timer 5 divisor to   256 for PWM frequency of   122.55 Hz
//  TCCR5B = TCCR5B & B11111000 | B00000101;    // set timer 5 divisor to  1024 for PWM frequency of    30.64 Hz
}

void enableTimerInterrupts()
{
  // Timer0 is already used for millis() - we'll just interrupt somewhere
  // in the middle and call the "Compare A" function below
  OCR0A = 0xAF;
  TIMSK0 |= _BV(OCIE0A);
}

// Timer Interrupt Function (called every millisecond)
SIGNAL(TIMER0_COMPA_vect)
{
  if (queued == true)
  {
    unsigned long currentTime = millis();
    if (inMotion == false && currentTime >= startTime)
    {
      inMotion = true;
      if (currentMotor == 'P') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_P, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_P, HIGH); }
        analogWrite(PIN_STEP_MOTOR_P, dutyCycleP);
      }
      else if (currentMotor == 'V') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_V, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_V, HIGH); }
        analogWrite(PIN_STEP_MOTOR_V, dutyCycleV);
        }
      else if (currentMotor == 'H') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_H, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_H, HIGH); }
        analogWrite(PIN_STEP_MOTOR_H, dutyCycleH);
      }
      else if (currentMotor == 'D') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_D, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_D, HIGH); }
        analogWrite(PIN_STEP_MOTOR_D, dutyCycleD);
      }
      else if (currentMotor == 'A') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_A, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_A, HIGH); }
        analogWrite(PIN_STEP_MOTOR_A, dutyCycleA);
      }
      else if (currentMotor == 'E') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_E, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_E, HIGH); }
        analogWrite(PIN_STEP_MOTOR_E, dutyCycleE);
      }
    }
    else if (inMotion == true && currentTime >= stopTime)
    {
      if (currentMotor == 'P') { analogWrite(PIN_STEP_MOTOR_P, 0); }
      else if (currentMotor == 'V') { analogWrite(PIN_STEP_MOTOR_V, 0); }
      else if (currentMotor == 'H') { analogWrite(PIN_STEP_MOTOR_H, 0); }
      else if (currentMotor == 'D') { analogWrite(PIN_STEP_MOTOR_D, 0); }
      else if (currentMotor == 'A') { analogWrite(PIN_STEP_MOTOR_A, 0); }
      else if (currentMotor == 'E') { analogWrite(PIN_STEP_MOTOR_E, 0); }
      inMotion = false;
      queued = false;
      sendToProgram(returnStringSuccess);
    }
  }
}

// Serial Event Handler
void serialEvent()
{
  char c = Serial.read();
  if (receiving == false)
  {
    receiving = true;
    inputLength = 0;
  }
  if (c == delimiter)
  {
    receiving = false;
    String input = String(inputBuffer);
    input = input.substring(0, inputLength);
    processStringInput(input);
  }
  else
  {
    inputBuffer[inputLength] = c;
    inputLength++;
  }
}

// Take input and call functions accordingly
void processStringInput(String input)
{
  int indexStatus = input.indexOf('s'); // Status Response
  int indexMotor = input.indexOf('m'); // Motor Response
  int indexDirection = input.indexOf('d'); // Direction Response
  int indexQuantity = input.indexOf('q'); // Quantity Response
  if (indexStatus >= 0)
  {
    returnStringSuccess = "sS";
    returnStringFailed = "sA";
    if (input[indexStatus + 1] == 'S')
    {
      stopMotors();
    }
    else if (input[indexStatus + 1] == 'A')
    {
      if (inMotion == true) {
        sendToProgram(returnStringFailed);
        return;
      }
      else if (indexMotor >= 0 && indexDirection >= 0 && indexQuantity >= 0)
      {
        char motor = input[indexMotor + 1];
        char dir = input[indexDirection + 1];
        String quantityStr = input.substring(indexQuantity + 1);
        float quantity = quantityStr.toFloat();
        returnStringSuccess.concat('m');
        returnStringSuccess.concat(motor);
        returnStringSuccess.concat('d');
        returnStringSuccess.concat(dir);
        returnStringSuccess.concat('q');
        returnStringSuccess.concat(quantity);
        moveMotor(motor, dir, quantity);
      }
    }
  }
}

//////////////////// Motor Functions ////////////////////
void enableMotors()
{
  digitalWrite(PIN_ENABLE_MOTORS, LOW);
}

void disableMotors()
{
  digitalWrite(PIN_ENABLE_MOTORS, HIGH);
}

void stopMotors()
{
  analogWrite(PIN_STEP_MOTOR_P, 0);
  analogWrite(PIN_STEP_MOTOR_V, 0);
  analogWrite(PIN_STEP_MOTOR_H, 0);
  analogWrite(PIN_STEP_MOTOR_D, 0);
  analogWrite(PIN_STEP_MOTOR_A, 0);
  analogWrite(PIN_STEP_MOTOR_E, 0);
  inMotion = false;
  queued = false;
  sendToProgram(returnStringSuccess);
}

void moveMotor(char motor, char dir, float quantity)
{
	if (inMotion == false)
	{
		currentMotor = motor;
    if (dir == 'P') { currentDirection = 1; }
    else if (dir == 'N') { currentDirection = -1; }
		float timeDuration = 0;
		if (currentMotor == 'P') {
		  timeDuration = quantity*timeScalarP;
		  currentDirection *= posDirP;
	  }
		else if (currentMotor == 'V') {
		  timeDuration = quantity*timeScalarV;
		  currentDirection *= posDirV;
	  }
		else if (currentMotor == 'H') {
		  timeDuration = quantity*timeScalarH;
		  currentDirection *= posDirH;
	  }
		else if (currentMotor == 'D') {
		  timeDuration = quantity*timeScalarD;
		  currentDirection *= posDirD;
	  }
		else if (currentMotor == 'A') {
		  timeDuration = quantity*timeScalarA;
		  currentDirection *= posDirA;
	  }
		else if (currentMotor == 'E') {
		  timeDuration = quantity*timeScalarE;
		  currentDirection *= posDirE;
		}
		startTime = millis();
		stopTime = startTime + (long)(timeDuration*1000);
    queued = true;
	}
}

//////////////////// Output Functions ////////////////////
void sendToProgram(String output)
{
  output.toCharArray(outputBuffer, bufferLength);
  Serial.write(outputBuffer);
  Serial.write(delimiter);
}


















//////////////////// OBSOLETE ////////////////////
//Example functions (will not be used in hte main program)
void JustPrint() {
    Serial.write("ABC123");
    Serial.write(delimiter);
}
void BounceBack() {
  if (Serial.available() > 0) {
    Serial.write(Serial.read());
  }
}
