const byte ledPin = 13; //led
const byte interruptPin = 3; //hall sensor
const int signalPin = 7;

volatile byte state = LOW;


void setup() {
  pinMode(ledPin, OUTPUT);
  pinMode(interruptPin, INPUT_PULLUP);
  pinMode(signalPin, OUTPUT);
  attachInterrupt(digitalPinToInterrupt(interruptPin), test, CHANGE);
  Serial.begin(9600);

}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(ledPin, state);
  Serial.println(state);

  if (state == HIGH) {
    digitalWrite(signalPin, state);
    Serial.println("Sent!");
  }
}

void test() {
  state = !state;
}
