//////////////////// CSUATR Arduino Code ////////////////////
// Current thoughts:
// Still need to implement limit switches
// current decay mode: %50 (half)
// micro-stepping: 1/16 (smallest)
// set current settings to be as close as possible to motor current settings

//////////////////// Serial Parameters ////////////////////
char delimiter = '>';
int const bufferLength = 100;
char inputBuffer[bufferLength];
int inputLength = 0;
bool receiving = false;
char outputBuffer[bufferLength];

//////////////////// Directional Parameters ////////////////////
// Motor Positive Direction (allows user to switch the direction indicated as 'positive')
int posDirH = 1;  // -1 -> reversed direction
int posDirV = 1;  // 1 -> normal direction
int posDirD = 1;
int posDirA = -1;
int posDirE = 1;
int posDirP = 1;

//////////////////// Pins ////////////////////
// Enable
const int PIN_ENABLE_MOTORS_1 = 50;
const int PIN_ENABLE_MOTORS_2 = 52;
// Direction
const int PIN_DIR_MOTOR_H = 37; //37
const int PIN_DIR_MOTOR_V = 39; //39
const int PIN_DIR_MOTOR_D = 41;
const int PIN_DIR_MOTOR_A = 43;
const int PIN_DIR_MOTOR_E = 49; //45
const int PIN_DIR_MOTOR_P = 35;
// Step
const int PIN_STEP_MOTOR_H = 3; //3
const int PIN_STEP_MOTOR_V = 2; //2
const int PIN_STEP_MOTOR_D = 6;
const int PIN_STEP_MOTOR_A = 7;
const int PIN_STEP_MOTOR_E = 8; //10
const int PIN_STEP_MOTOR_P = 9;
// Limit Switches
const int PIN_LIMIT_H = 36;
const int PIN_LIMIT_V = 38;
const int PIN_LIMIT_D = 40;
const int PIN_LIMIT_A = 42;
const int PIN_LIMIT_E = 44;
const int PIN_LIMIT_P = 46;

//////////////////// Operational Parameters ////////////////////
// Current Attributes
char currentStatus = 'S';		 // motion status
char currentMotor = 'H';		 // motor being moved
char currentDirection = 'P'; // direction
float currentAlpha = 1.00;   // alpha coefficient
float currentBeta = 1.00;    // beta coefficient
float currentGamma = 1.00;   // gamma coefficient

// primary motion influences
float currentTarget = 0.00;  // movement quantity target
float currentQuantity = 0.00;   // current movement quantity

// Most Recent Encoder Position (Feedback)
int encoderH = 0;
int encoderV = 0;
int encoderD = 0;
int encoderA = 0;
int encoderE = 0;
int encoderP = 0;

// Timing Attributes (Feedback)
unsigned long currentMillis = 0;
unsigned long startMillis = 0;
unsigned long elapsedMillis = 0;


//////////////////// Feedback Control ////////////////////

// Define additional variables here
float frequency = 1;
float a = 1;
float b = 1;
float e = 2.71828;
unsigned long rotationCount = 0; // delete this

void startMotor(char motor, char direction, float quantity, float alpha, float beta, float gamma) {
	if (currentStatus == 'S')
	{
		setMotor(motor);
		setDirection(motor, direction);
		setAlpha(alpha);
		setBeta(beta);
		setGamma(gamma);
		setTarget(quantity);
		currentQuantity = 0;
		
		
		///////// Place additional setup here /////////

    frequency = currentAlpha;
    a = currentBeta;
		b = currentGamma;
		
		setSpeed(currentMotor, frequency);
		
		///////////////////////////////////////////////
		
		startMillis = millis();
    rotationCount = 0; // delete this
		enableFeedback();
	}
}
void feedbackControl() {
	if (currentStatus == 'A')
	{
  rotationCount += 1; // delete this
		///////// Place feedback code here /////////
		// Control Parameters (these are useful to you):
			// currentAlpha
			// currentBeta
			// currentGamma
		
		// Feedback Parameters (these are useful to you)
			// currentTarget (centimeters or degrees)
			// encoderPos(motor) (counts, (will need to convert))
			// elapsedMillis (milliseconds)

		// Actuators (this is how you control stuff)
			// setSpeed(motor, frequency)
			// stopMotor(motor)
			
		// Updates (you need to update these every time)
			// currentQuantity

		float t = elapsedMillis / 1000.0; // get time in seconds
    currentQuantity = (b*t - (b/a)) + ((b/a)*exp(-a*t));
		if (currentQuantity >= currentTarget) {
			stopMotor(currentMotor);
		}
		////////////////////////////////////////////
	}
}


//////////////////// Constructor ////////////////////
void setup() {
  Serial.begin(9600); // This baud rate should be the same as the CSUATR Program
  
  pinMode(PIN_ENABLE_MOTORS_1, OUTPUT);
  pinMode(PIN_ENABLE_MOTORS_2, OUTPUT);
  
	pinMode(PIN_DIR_MOTOR_H, OUTPUT);
	pinMode(PIN_DIR_MOTOR_V, OUTPUT);
	pinMode(PIN_DIR_MOTOR_D, OUTPUT);
	pinMode(PIN_DIR_MOTOR_A, OUTPUT);
	pinMode(PIN_DIR_MOTOR_E, OUTPUT);
	pinMode(PIN_DIR_MOTOR_P, OUTPUT);

	pinMode(PIN_STEP_MOTOR_H, OUTPUT);
	pinMode(PIN_STEP_MOTOR_V, OUTPUT);
	pinMode(PIN_STEP_MOTOR_D, OUTPUT);
	pinMode(PIN_STEP_MOTOR_A, OUTPUT);
	pinMode(PIN_STEP_MOTOR_E, OUTPUT);
	pinMode(PIN_STEP_MOTOR_P, OUTPUT);

	pinMode(PIN_LIMIT_H, INPUT_PULLUP);
	pinMode(PIN_LIMIT_V, INPUT_PULLUP);
	pinMode(PIN_LIMIT_D, INPUT_PULLUP);
	pinMode(PIN_LIMIT_A, INPUT_PULLUP);
	pinMode(PIN_LIMIT_E, INPUT_PULLUP);
	pinMode(PIN_LIMIT_P, INPUT_PULLUP);
	
	// TODO: Encoders

	enableLimitSwitchInterrupts();
	enableMotors();
  setStatus('S');
}
void loop(){
  // Timer Interrupt Function (called every millisecond)
  currentMillis = millis();
  elapsedMillis = currentMillis - startMillis;
  
  // TODO: get encoder positions
  encoderH = 0;
  encoderV = 0;
  encoderD = 0;
  encoderA = 0;
  encoderE = 0;
  encoderP = 0;
  
  feedbackControl();
}

//////////////////// Limit Switch Interrupts ////////////////////
void enableLimitSwitchInterrupts() {
	attachInterrupt(digitalPinToInterrupt(PIN_LIMIT_H), triggeredHorizontal, CHANGE);
	attachInterrupt(digitalPinToInterrupt(PIN_LIMIT_V), triggeredVertical, CHANGE);
	attachInterrupt(digitalPinToInterrupt(PIN_LIMIT_D), triggeredDepth, CHANGE);
	attachInterrupt(digitalPinToInterrupt(PIN_LIMIT_A), triggeredAzimuth, CHANGE);
	attachInterrupt(digitalPinToInterrupt(PIN_LIMIT_E), triggeredElevation, CHANGE);
	attachInterrupt(digitalPinToInterrupt(PIN_LIMIT_P), triggeredPolarization, CHANGE);
}
void triggeredHorizontal() {
	stopMotor('H');
	sendStatus();
}
void triggeredVertical() {
	stopMotor('V');
	sendStatus();
}
void triggeredDepth() {
	stopMotor('D');
	sendStatus();
}
void triggeredAzimuth() {
	stopMotor('A');
	sendStatus();
}
void triggeredElevation() {
	stopMotor('E');
	sendStatus();
}
void triggeredPolarization() {
	stopMotor('P');
	sendStatus();
}

//////////////////// Serial Interrupts and Functions ////////////////////
void serialEvent() {
	// Serial Event Handler
  char c = Serial.read();
  if (receiving == false) {
    receiving = true;
    inputLength = 0;
  }
  if (c == delimiter) {
    receiving = false;
    String input = String(inputBuffer);
    input = input.substring(0, inputLength);
    processStringInput(input);
  }
  else {
    inputBuffer[inputLength] = c;
    inputLength++;
  }
}
void processStringInput(String input) {
	// This will either do one of three things:
	// (1) Stop the current movement if it is active and notify user
	// (2) Notify the user if current action is active and user asks to start another movement
	// (3) Start a new movement if the current movement is not active 
  int indexStatus = input.indexOf('s'); // Status Response (stopped or active)
  int indexMotor = input.indexOf('m'); // Motor Response (motor)
  int indexDirection = input.indexOf('d'); // Direction Response (direction)
	int indexQuantity = input.indexOf('q'); // Quantity Response (quantity)
	int indexAlpha = input.indexOf('a'); // Alpha Response (alpha)
	int indexBeta = input.indexOf('b'); // Beta Response (beta)
	int indexGamma = input.indexOf('g'); // Gamma Response (gamma)
	
  if (indexStatus >= 0) {
		char status = input[indexStatus + 1];
    if (status == 'S') {
			stopAllMotors();
			return;
    }
    else if (status == 'A') {
      if (currentStatus == 'A') {
        sendStatus();
        return;
      }
      else if (
					indexMotor >= 0 &&
					indexDirection >= 0 &&
					indexQuantity >= 0 &&
					indexAlpha >= 0 &&
					indexBeta >= 0 &&
					indexGamma >= 0) {
        char motor = input[indexMotor + 1];
        char direction = input[indexDirection + 1];
        String strQuantity = input.substring(indexQuantity + 1, indexAlpha);
        float quantity = strQuantity.toFloat();
				String strAlpha = input.substring(indexAlpha + 1, indexBeta);
        float alpha = strAlpha.toFloat();
				String strBeta = input.substring(indexBeta + 1, indexGamma);
        float beta = strBeta.toFloat();
				String strGamma = input.substring(indexGamma + 1);
        float gamma = strGamma.toFloat();
        startMotor(motor, direction, quantity, alpha, beta, gamma);
      }
    }
  }
}
void sendNotification() {
  String returnString = "A: ";
  returnString.concat(currentQuantity);
	returnString.concat("B: ");
	returnString.concat(currentTarget);
  returnString.toCharArray(outputBuffer, bufferLength);
  Serial.write(outputBuffer);
  Serial.write(delimiter);
}
void sendStatus() {
	String returnString = "s";
	returnString.concat(currentStatus);
	returnString.concat('m');
	returnString.concat(currentMotor);
	returnString.concat('d');
	returnString.concat(currentDirection);
	returnString.concat('q');
	returnString.concat(currentQuantity);
	returnString.concat('a');
	returnString.concat(currentAlpha);
	returnString.concat('b');
	returnString.concat(currentBeta);
	returnString.concat('g');
	returnString.concat(currentGamma);
  returnString.toCharArray(outputBuffer, bufferLength);
  Serial.write(outputBuffer);
  Serial.write(delimiter);
}

//////////////////// Encoder Functions ////////////////////
int encoderPos(char motor) {
	// TODO: convert counts to units (cm or deg.)
	if (motor == 'H') { return encoderH; }
	else if (motor == 'V') { return encoderV; }
	else if (motor == 'D') { return encoderD; }
	else if (motor == 'A') { return encoderA; }
	else if (motor == 'E') { return encoderE; }
	else if (motor == 'P') { return encoderP; }
}

//////////////////// Motor Functions ////////////////////
void enableMotors() {
  digitalWrite(PIN_ENABLE_MOTORS_1, LOW);
  digitalWrite(PIN_ENABLE_MOTORS_2, LOW);
}
void disableMotors() {
  digitalWrite(PIN_ENABLE_MOTORS_1, HIGH);
  digitalWrite(PIN_ENABLE_MOTORS_2, HIGH);
}
void enableFeedback() {
	setStatus('A');
}
void stopMotor(char motor) {
	setStatus('S');
	if (motor == 'H') { noTone(PIN_STEP_MOTOR_H); }
	else if (motor == 'V') { noTone(PIN_STEP_MOTOR_V); }
	else if (motor == 'D') { noTone(PIN_STEP_MOTOR_D); }
	else if (motor == 'A') { noTone(PIN_STEP_MOTOR_A); }
	else if (motor == 'E') { noTone(PIN_STEP_MOTOR_E); }
	else if (motor == 'P') { noTone(PIN_STEP_MOTOR_P); }
	sendStatus();
}
void stopAllMotors() {
	setStatus('S');
	noTone(PIN_STEP_MOTOR_H);
	noTone(PIN_STEP_MOTOR_V);
	noTone(PIN_STEP_MOTOR_D);
	noTone(PIN_STEP_MOTOR_A);
	noTone(PIN_STEP_MOTOR_E);
	noTone(PIN_STEP_MOTOR_P);
	sendStatus();
}
void setSpeed(char motor, float frequency) {
	if (motor == 'H') { tone(PIN_STEP_MOTOR_H, frequency); }
	else if (motor == 'V') { tone(PIN_STEP_MOTOR_V, frequency); }
	else if (motor == 'D') { tone(PIN_STEP_MOTOR_D, frequency); }
	else if (motor == 'A') { tone(PIN_STEP_MOTOR_A, frequency); }
	else if (motor == 'E') { tone(PIN_STEP_MOTOR_E, frequency); }
	else if (motor == 'P') { tone(PIN_STEP_MOTOR_P, frequency); }
}

//////////////////// Status Functions ////////////////////
void setStatus(char status) {
	currentStatus = status;
}
void setMotor(char motor) {
	currentMotor = motor;
}
void setDirection(char motor, char direction) {
	currentDirection = direction;
	int dir = 1;
	if (direction == 'N') { dir = -1; }
	if (motor == 'H') { dir *= posDirH; }
	else if (motor == 'V') { dir *= posDirV; }
	else if (motor == 'D') { dir *= posDirD; }
	else if (motor == 'A') { dir *= posDirA; }
	else if (motor == 'E') { dir *= posDirE; }
	else if (motor == 'P') { dir *= posDirP; }
	if (currentMotor == 'H') {
		if (dir > 0) { digitalWrite(PIN_DIR_MOTOR_H, LOW); }
		else { digitalWrite(PIN_DIR_MOTOR_H, HIGH); }
	}
	else if (currentMotor == 'V') {
		if (dir > 0) { digitalWrite(PIN_DIR_MOTOR_V, LOW); }
		else { digitalWrite(PIN_DIR_MOTOR_V, HIGH); }
	}
	else if (currentMotor == 'D') {
		if (dir > 0) { digitalWrite(PIN_DIR_MOTOR_D, LOW); }
		else { digitalWrite(PIN_DIR_MOTOR_D, HIGH); }
	}
	else if (currentMotor == 'A') {
		if (dir > 0) { digitalWrite(PIN_DIR_MOTOR_A, LOW); }
		else { digitalWrite(PIN_DIR_MOTOR_A, HIGH); }
	}
	else if (currentMotor == 'E') {
		if (dir > 0) { digitalWrite(PIN_DIR_MOTOR_E, LOW); }
		else { digitalWrite(PIN_DIR_MOTOR_E, HIGH); }
	}
	else if (currentMotor == 'P') {
		if (dir > 0) { digitalWrite(PIN_DIR_MOTOR_P, LOW); }
		else { digitalWrite(PIN_DIR_MOTOR_P, HIGH); }
	}
}
void setTarget(float quantity) {
	currentTarget = quantity;
}
void setAlpha(float alpha) {
	currentAlpha = alpha;
}
void setBeta(float beta) {
	currentBeta = beta;
}
void setGamma(float gamma) {
	currentGamma = gamma;
}
