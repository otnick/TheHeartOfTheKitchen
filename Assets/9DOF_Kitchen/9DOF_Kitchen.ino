#include <SparkFunLSM9DS1.h>
#include <MadgwickAHRS.h>
#include <Wire.h>
#include <WiFi.h>
#include <WebSocketsClient.h>
#include <Adafruit_NeoPixel.h>
#include <header.h>
#include "MovingAverage.h"

// --------------------------------------------------
// WiFi / Server Settings
// --------------------------------------------------
const char *ssid = "dsv-extrality-lab";            // Enter your Wi-Fi name

const char *password = "expiring-unstuck-slider";  // Enter Wi-Fi password
const char* serverIP = "10.204.0.62"; //Replace with your Python server's IP (e.g. 192.168.1.111)
const uint16_t serverPort = 8081; //Replace with your desired Port (or keep as is)


int windowSize = 20;

MovingAverage movingAverage(windowSize);

// At the top, global variables
unsigned long lastPrint = 0;
int loopCount = 0;


// --------------------------------------------------
// WebSocket events setup
// --------------------------------------------------
void webSocketEvent(WStype_t type, uint8_t* payload, size_t length) {

  switch(type) {

  
    case WStype_CONNECTED: {
      Serial.printf("WebSocket connected to %s:%u\n", serverIP, serverPort);
      String message = String("Device: ") + BOARD_NAME + " ... MAC: " + WiFi.macAddress();
      webSocket.sendTXT(message);
      break;
    }

    case WStype_DISCONNECTED:
      Serial.println("Not connected to WebSocket server... Retrying in 5 seconds");
      break;

    case WStype_TEXT:
      payload[length] = '\0';
      Serial.print("WebSocket received: ");
      Serial.println((char*)payload);
      handleMessage(String((char*)payload));
      break;
  }
}

// --------------------------------------------------
// WebSocket message handler. Edit for new RECEIVED WebSocket Messages
// --------------------------------------------------
void handleMessage(const String& message) { // This function is set up to receive and parse messages in the form of "TYPE:VALUE" (e.g. Led:55)
  int sep = message.indexOf(':');
  if (sep == -1) return;

  String type = message.substring(0, sep);
  int value = message.substring(sep + 1).toInt();

  if(type.equalsIgnoreCase("CUSTOM WEBSOCKET MESSAGE")) {
    //Do something
  }

}

void setup() {
  Serial.begin(115200);
  
  // // Tell ESP32-S2 which pins to use for I2C
  // Wire.begin(1, 2); // SDA= 1, SCL=2 (Thing Plus S2 default)

  // imu.settings.device.commInterface = IMU_MODE_I2C;
  // imu.settings.device.mAddress = LSM9DS1_M;
  // imu.settings.device.agAddress = LSM9DS1_AG;
  // imu.settings.accel.scale = 16; // Set accel range to +/-16g
  // imu.settings.gyro.scale = 2000; // Set gyro range to +/-2000dps
  // imu.settings.mag.scale = 8; // Set mag range to +/-8Gs

  // if (!imu.begin()) {
  //   Serial.println("LSM9DS1 not detected. Check wiring!");
  //   while (1);
  // }

  // filter.begin(SAMPLE_RATE);
  // filter.setBeta(10.0);
  // for (int i = 0; i < 500; i++) {
  //   imu.readAccel();
  //   imu.readGyro();
  //   imu.readMag();

  //   filter.update(
  //     imu.calcGyro(imu.gx),
  //     imu.calcGyro(imu.gy),
  //     imu.calcGyro(imu.gz),
  //     imu.calcAccel(imu.ax),
  //     imu.calcAccel(imu.ay),
  //     imu.calcAccel(imu.az),
  //     imu.calcMag(imu.mx),
  //     imu.calcMag(imu.my),
  //     imu.calcMag(imu.mz)
  //   );
  //   delay(5); // ~200Hz
  // }
  // filter.setBeta(FILTER_BETA);
  for (int i = 0; i < windowSize; i++){
  movingAverage.update(200);
  }

  WiFi.begin(ssid, password);
  Serial.printf("Connecting to WiFi: %s", ssid);
  while (WiFi.status() != WL_CONNECTED) { //Waiting for conection to wifi
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nWiFi connected");
  Serial.printf("Attempting to connect to WebSocket Server on %s\n", serverIP);

  webSocket.begin(serverIP, serverPort, "/");
  webSocket.onEvent(webSocketEvent);
  webSocket.setReconnectInterval(5000);

}

bool forceSensor(){
  int value = analogReadMilliVolts(5);
  movingAverage.update(value);
  value = movingAverage.getAverage(); 
  Serial.print("Force observed: ");
  Serial.println(value);

  if (value > 100) {Serial.println("im grinding daddy");return true;}
  return false;
}

  void loop() {
  webSocket.loop();
  if (forceSensor()){
    webSocket.sendTXT("grinder:1");
  }

}

// void NineDOF(){
//   static unsigned long lastUpdate = 0;
//   unsigned long now = millis();
//   // At the top, global variables
//   loopCount++;

//   // Print actual rate every second
//   if (now - lastPrint >= 1000) {
//     Serial.print("Loop rate: ");
//     Serial.print(loopCount);
//     Serial.println(" Hz");
//     loopCount = 0;
//     lastPrint = now;
//   }

//   if (now - lastUpdate >= (1000 / SAMPLE_RATE)) {
//     lastUpdate = now;

//     imu.readAccel();
//     imu.readGyro();
//     imu.readMag();

//     const float GYRO_TO_RAD = PI / 180.0f;

//     float gx = imu.calcGyro(imu.gx);  
//     float gy = imu.calcGyro(imu.gy);
//     float gz = imu.calcGyro(imu.gz);

//     float ax = imu.calcAccel(imu.ax);
//     float ay = imu.calcAccel(imu.ay);
//     float az = imu.calcAccel(imu.az);

//     float mx = imu.calcMag(imu.mx);
//     float my = imu.calcMag(imu.my);
//     float mz = imu.calcMag(imu.mz);

//     filter.update(gx, gy, gz, ax, ay, az, mx, my, mz);

//     // ✅ Use the public Euler getters
//     float roll  = filter.getRoll();
//     float pitch = filter.getPitch();
//     float yaw   = filter.getYaw();

//     // Serial.print(roll);  Serial.print(",");
//     // Serial.print(pitch); Serial.print(",");
//     // Serial.println(yaw);

//     char packet[128];
//     snprintf(packet, sizeof(packet),
//       // "PAN-%.4f,%.4f,%.4f,%.4f,%.4f,%.4f,%.4f,%.4f,%.4f,%.4f",
//       "PAN:%.4f,%.4f,%.4f,%.4f",
//       roll, pitch, yaw    // orientation in degrees
//       // ax, ay, az,          // linear acceleration
//       // gx, gy, gz           // angular velocity
//     );


//   //Serial.print("string volts: ");

//   // Serial.println(packet);
//   Serial.print("Raw: ");   Serial.print(imu.gx);
//   Serial.print(" Calc: "); Serial.println(imu.calcGyro(imu.gx));
//   return;
// }
