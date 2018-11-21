#include <SoftwareSerial.h>
//#include <CapacitiveSensor.h>
#include <Wire.h>

// #define TOUCH 7
//int led = 12;
const int MPU = 0x68;
int GyX, GyY, GyZ;
int fsrPin = 0;     // the FSR and 10K pulldown are connected to a0
int fsrReading;

const int trigPin = 8;
const int echoPin = 9;


// defines variables
long duration;
int distance;

void setup() {
  Wire.begin();
  Wire.beginTransmission(MPU);
  Wire.write(0x6B);
  Wire.write(0);
  Wire.endTransmission(true);
  pinMode(trigPin, OUTPUT); // Sets the trigPin as an Output
  pinMode(echoPin, INPUT); // Sets the echoPin as an Input
//  pinMode(led,OUTPUT);
//  pinMode(TOUCH, INPUT);
  Serial.begin(9600); // Starts the serial communication
}

void loop() {


//FORMAT OF OUTPUT ---- fsr,ultrasonic,gyro1,gyro2,gyro3

  //FOR ULTRASONIC
  // Clears the trigPin
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  // Sets the trigPin on HIGH state for 10 micro seconds
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  // Reads the echoPin, returns the sound wave travel time in microseconds
  duration = pulseIn(echoPin, HIGH);
  // Calculating the distance
  distance= duration*0.034/2;

  delay(100);

//FOR GYROSCOPE
  Wire.beginTransmission(MPU);
  Wire.write(0x3B);
  Wire.endTransmission(false);
  Wire.requestFrom(MPU, 12, true);
int AcX=Wire.read()<<8|Wire.read();
   int AcY=Wire.read()<<8|Wire.read();
   int AcZ=Wire.read()<<8|Wire.read();
int16_t tmp=Wire.read()<<8|Wire.read(); 
  GyX = Wire.read() << 8 | Wire.read();
  GyY = Wire.read() << 8 | Wire.read();
  GyZ = Wire.read() << 8  | Wire.read();



//FORCE SESNSITIVE RESISTOR
fsrReading = analogRead(fsrPin); 
//Serial.print(fsrReading); 
//Serial.print("fsrReading"); 
if (fsrReading <= 160 ) {
    Serial.print("0");
    Serial.print(",");
    }
else {
    Serial.print("1");
    Serial.print(",");
  }
delay(100);


// PRINT the distance on the Serial Monitor
//Serial.println(distance);
//Serial.print("distance"); 
  if(distance>=4 && distance<=25)
  {
    Serial.print(distance); 
  }
  else
  {
    Serial.print("0");
  }
  Serial.print(",");
//  Serial.print("gyro"); 
  Serial.print(tmp);
  Serial.print(",");
  Serial.print(GyX / 100); 
  Serial.print(",");
  Serial.print(GyY / 100);
  Serial.print(",");
  Serial.println(GyZ / 100);
  
  
  delay(100);
}
