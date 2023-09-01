//////////////////// CSUATR Arduino Code ////////////////////
// Current thoughts:
// Still need to implement limit switches
// maxDutyCycles and timeScalars need to be come function of position

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

// Concept:
// position = velocity  * time
// time = quantity * timeScalar
// velocity = dutyCycle * motorScalar

// Scalars for duty cycle
int maxDutyCycleP = 50; // from 0 to 255
int maxDutyCycleV = 50;
int maxDutyCycleH = 50;
int maxDutyCycleD = 50;
int maxDutyCycleA = 50;
int maxDutyCycleE = 50;

// Scalars for quantity
float timeScalarP = 1000.0; // converts physical quantity into movement timing
float timeScalarV = 1.0; // (will change with duty cycle also)
float timeScalarH = 1.0;
float timeScalarD = 1.0;
float timeScalarA = 1.0;
float timeScalarE = 1.0;

// Motor Positive Direction (allows user to switch the direction indicated as 'positive')
int posDirP = 1;  // 1 -> normal direction
int posDirV = 1;  // -1 -> reversed direction
int posDirH = 1;
int posDirD = 1;
int posDirA = 1;
int posDirE = 1;


//////////////////// Pins ////////////////////
// Enable
const int PIN_ENABLE_MOTORS = 0;

// Polarization (P)
const int PIN_DIR_MOTOR_P = 0;
const int PIN_STEP_MOTOR_P = 0;
// Vertical     (V)
const int PIN_DIR_MOTOR_V = 0;
const int PIN_STEP_MOTOR_V = 0;
// Horizontal   (H)
const int PIN_DIR_MOTOR_H = 0;
const int PIN_STEP_MOTOR_H = 0;
// Depth        (D)
const int PIN_DIR_MOTOR_D = 0;
const int PIN_STEP_MOTOR_D = 0;
// Azimuth      (A)
const int PIN_DIR_MOTOR_A = 0;
const int PIN_STEP_MOTOR_A = 0;
// Elevation    (E)
const int PIN_DIR_MOTOR_E = 0;
const int PIN_STEP_MOTOR_E = 0;

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
//    String sendStr = "TIME"; // delete line
//    sendStr.concat(currentTime); // delete line
    if (inMotion == false && currentTime >= startTime)
    {
//      sendToProgram(sendStr); // delete line
      inMotion = true;
      if (currentMotor == 'P') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_P, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_P, HIGH); }
        analogWrite(PIN_STEP_MOTOR_P, maxDutyCycleP);
      }
      else if (currentMotor == 'V') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_V, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_V, HIGH); }
        analogWrite(PIN_STEP_MOTOR_V, maxDutyCycleV);
        }
      else if (currentMotor == 'H') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_H, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_H, HIGH); }
        analogWrite(PIN_STEP_MOTOR_H, maxDutyCycleH);
      }
      else if (currentMotor == 'D') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_D, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_D, HIGH); }
        analogWrite(PIN_STEP_MOTOR_D, maxDutyCycleD);
      }
      else if (currentMotor == 'A') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_A, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_A, HIGH); }
        analogWrite(PIN_STEP_MOTOR_A, maxDutyCycleA);
      }
      else if (currentMotor == 'E') {
        if (currentDirection > 0) { digitalWrite(PIN_DIR_MOTOR_E, LOW); }
        else { digitalWrite(PIN_DIR_MOTOR_E, HIGH); }
        analogWrite(PIN_STEP_MOTOR_E, maxDutyCycleE);
      }
    }
    else if (inMotion == true && currentTime >= stopTime)
    {
//      sendToProgram(sendStr); // delete line
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
//        sendToProgram(returnStringSuccess); // delete line
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
		float timeScalar = 0;
		if (currentMotor == 'P') {
		  timeScalar = timeScalarP;
		  currentDirection *= posDirP;
	  }
		else if (currentMotor == 'V') {
		  timeScalar = timeScalarV;
		  currentDirection *= posDirV;
	  }
		else if (currentMotor == 'H') {
		  timeScalar = timeScalarH;
		  currentDirection *= posDirH;
	  }
		else if (currentMotor == 'D') {
		  timeScalar = timeScalarD;
		  currentDirection *= posDirD;
	  }
		else if (currentMotor == 'A') {
		  timeScalar = timeScalarA;
		  currentDirection *= posDirA;
	  }
		else if (currentMotor == 'E') {
		  timeScalar = timeScalarE;
		  currentDirection *= posDirE;
		}
		startTime = millis();
		stopTime = startTime + (long)(quantity*timeScalar);
    queued = true;
   
//    String str1 = "START TIME"; // delete line
//    String str2 = "STOP TIME"; // delete line
//    str1.concat(startTime); // delete line
//    str2.concat(stopTime); // delete line
//    sendToProgram(str1); // delete line
//    sendToProgram(str2); // delete line
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
