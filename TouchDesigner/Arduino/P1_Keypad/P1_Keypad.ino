#include <Keypad.h>

const int maglock =  10;
const byte ROWS = 4; //four rows
const byte COLS = 4; //three columns
char keys[ROWS][COLS] = {
  {'1','2','3','A'},
  {'4','5','6','B'},
  {'7','8','9','C'},
  {'*','0','#','D'}
};

byte rowPins[ROWS] = {2, 3, 4, 5}; //connect to the row pinouts of the keypad
byte colPins[COLS] = {6,7,8,9}; //connect to the column pinouts of the keypad

char key;
char correct[4] = {'1','3','3','4'};
char code[4] = {0,0,0,0};
int count = 0;

int flag = 0;

Keypad keypad = Keypad( makeKeymap(keys), rowPins, colPins, ROWS, COLS );

void setup(){
  Serial.begin(9600);
  pinMode(maglock, OUTPUT);
  digitalWrite(maglock, HIGH);
}
  
void loop(){

    // just print the pressed key
   while (flag == 0) {
   while (count < 4) {
      key = keypad.getKey();
   if (key){
    Serial.print(key);
    code[count] = key;
    count++;
  } 
   }
   check();
   count = 0;
   Serial.println();
   }
   Serial.println("ACCESS GRANTED");
   while (key != 'D') {
   key = keypad.getKey();
   digitalWrite(maglock, LOW);
   }
   digitalWrite(maglock, HIGH);
   flag = 0;
}

void check (void) {
  for (int i = 0; i < 4; i++) {
    if (correct[i] != code[i]) {
      flag = 0;
      return;
    }
}
flag = 1;
return;
}
