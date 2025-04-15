/*
  -- ESP32 XD - CARRITO --
   
  download by link http://remotexy.com/en/library/
  To connect using RemoteXY mobile app by link http://remotexy.com/en/download/                   

*/

//////////////////////////////////////////////
//        RemoteXY include library          //
//////////////////////////////////////////////

// you can enable debug logging to Serial at 115200
//#define REMOTEXY__DEBUGLOG    

// RemoteXY select connection mode and include library

#define REMOTEXY_MODE__WIFI_POINT

#include <WiFi.h>

// RemoteXY connection settings 
#define REMOTEXY_WIFI_SSID "RemoteXY"
#define REMOTEXY_WIFI_PASSWORD "12345678"
#define REMOTEXY_SERVER_PORT 6377
#define REMOTEXY_ACCESS_PASSWORD "1234"

#include <RemoteXY.h>

// RemoteXY GUI configuration  
#pragma pack(push, 1)  
uint8_t RemoteXY_CONF[] =   // 90 bytes
  { 255,4,0,1,0,83,0,19,0,0,0,67,97,114,95,99,111,110,116,114,
  111,108,0,204,2,106,200,200,84,1,1,4,0,5,19,121,70,70,14,36,
  40,40,32,164,26,31,1,56,53,45,45,134,51,22,22,0,2,31,73,78,
  84,0,70,9,58,28,28,92,6,24,24,16,36,135,0,1,51,124,52,52,
  164,51,22,22,0,2,31,66,90,0 };
  
// this structure defines all the variables and events of your control interface 
struct {

    // input variables
  int8_t joystick_01_x; // from -100 to 100
  int8_t joystick_01_y; // from -100 to 100
  uint8_t Intermitentes_1; // =1 if button pressed, else =0
  uint8_t Buzzer_1; // =1 if button pressed, else =0

    // output variables
  uint8_t led_01; // from 0 to 1

    // other variable
  uint8_t connect_flag;  // =1 if wire connected, else =0

} RemoteXY;

#pragma pack(pop)
 
/////////////////////////////////////////////
//           END RemoteXY include          //
/////////////////////////////////////////////

#include <Arduino.h>

///////////////////////////////////////////
//           Salidas del ESP32           //
///////////////////////////////////////////

#define LED 2

// Puentes H

#define BridgeHDown_L 2 // HBDownC (Puente H trasero antihorario)
#define BridgeHDown_R 4 // HBDownAC (Puente H trasero horario)

#define BridgeHUp_L 5 // HBUpC (Puente H delantero antihorario)
#define BridgeHUp_R 12 // HBUpAC (Puente H delantero horario)

//Aplicación: Intermitente, Direccionales y Buzzer (IDB)

#define INT_R 18  // Intermitente lateral derecho (LLD)
#define INT_L 19  // Intermitente lateral izquierdo (LLI)
#define BZ1 21 // IDB3

////////////////////////////////////////////////
//           Variables y Funciones           //
////////////////////////////////////////////////

// Variables //

int JoystickY = RemoteXY.joystick_01_y;
int JoystickX = RemoteXY.joystick_01_x;
int Buzzer_Button = RemoteXY.Buzzer_1;
int Int_Button = RemoteXY.Intermitentes_1;

// Funciones del carrito //

void ConexionESP ();
void Direccionales (int JoystickY, int JoystickX);
void Intermitentes_Bz ();

///////////////////////////////////
//           Codigo              //
///////////////////////////////////

void setup() { // Solo ejecuta una vez el comando, no actualiza valores

  Serial.begin(9600);  // Inicializar la comunicación serial. ¡NO TOCAR!

  pinMode(LED, OUTPUT);

  pinMode(BridgeHUp_R, OUTPUT);
  pinMode(BridgeHUp_L, OUTPUT);
  pinMode(BridgeHDown_L, OUTPUT);
  pinMode(BridgeHDown_R, OUTPUT);

  pinMode(INT_R, OUTPUT);
  pinMode(INT_L, OUTPUT);
  pinMode(BZ1, OUTPUT);

  RemoteXY_Init(); // Inicializa la conexión WiFi del RemoteXY
}

void loop() { // Se mantiene ejecutando el comando hasta que se acabe, ¡Cuidado con los bucles!

  RemoteXY_Handler(); // Actualiza los valores de RemoteXY. ¡NO TOCAR!
  // do not call delay(), use instead RemoteXY_delay()

  ConexionESP(); // Funcion para verificar la conexion del ESP32 a la Aplicacion del RemoteXY mediante un LED. Aqui usamos el primer ejemplo de AntiSpam.
  Direccionales(JoystickY, JoystickX); // Funcion para manipular el voltaje que reciben los Puente H, permitiendo el movimiento del carrito
  Intermitentes_Bz(); // Claxon e Intermitentes del carrito
}

void ConexionESP (){

  int estadoAnteriorConexion = 0;  // Almacena el estado anterior de conexión del ESP32. Evita el Spam.

  // Para que el LED, tanto del control como del ESP32, se enciendan cuando estamos conectados y apague si desconectamos //

  if (RemoteXY.connect_flag == 1 && !estadoAnteriorConexion) {

    RemoteXY.led_01 = 1;
    digitalWrite(LED, HIGH);
    Serial.println("El dispositivo se ha conectado correctamente al ESP32.");
    estadoAnteriorConexion = true;
  }
  
  else if (RemoteXY.connect_flag != 1 && estadoAnteriorConexion) {
    RemoteXY.led_01 = 0;
    digitalWrite(LED, LOW);
    Serial.println("El dispositivo ha perdido la conexion del ESP32.");
    estadoAnteriorConexion = false;
  }
}

void Direccionales(int JoystickY, int JoystickX) {

  /*  Funcion que depende de la ubicacion detectada del Joystick, controle el voltaje de salida del ESP32
  permitiendo el movimiento del carrito   */

  int ultimoEstadoY = 0;      // Almacena el estado anterior del eje Y del Joystick. Evita el Spam.
  int ultimoEstadoX = 0;

  if (JoystickY > 20 && ultimoEstadoY != 20) {
    
    // Adelante

    RemoteXY_delay(1500);       // Trato de que se espere un tiempo para marcar la coordenada de arranque

    digitalWrite(BridgeHDown_R, HIGH); // pin 4
    digitalWrite(BridgeHUp_R, HIGH); // pin 12

    digitalWrite(BridgeHUp_L, LOW); // pin 5
    digitalWrite(BridgeHDown_L, LOW); // pin 2
    
    Serial.print("El joystick se mueve hacia adelante a: ");
    Serial.println(JoystickY);
  }

  if (JoystickY < -20 && ultimoEstadoY != -20) {

    // Retroceso

    RemoteXY_delay(1500);
    
    digitalWrite(BridgeHUp_L, HIGH); // pin 5
    digitalWrite(BridgeHDown_L, HIGH); // pin 2

    digitalWrite(BridgeHUp_R, LOW); // pin 12
    digitalWrite(BridgeHDown_R, LOW); // pin 4
    
    Serial.print("El joystick se mueve hacia atras a: ");
    Serial.println(JoystickY);
  }

  if (JoystickY > 0 && ultimoEstadoY != 0) {
    
    // Detener
    
    RemoteXY_delay(1500);

    digitalWrite(BridgeHUp_L, LOW); // pin 5
    digitalWrite(BridgeHDown_L, LOW); // pin 2

    digitalWrite(BridgeHUp_R, LOW); // pin 12
    digitalWrite(BridgeHDown_R, LOW); // pin 4

    Serial.println("El joystick ha dejado de moverse");
  }

  if (JoystickX > 20 && ultimoEstadoX != 20) {

    // Hacia la derecha

    RemoteXY_delay(1500);

    digitalWrite(BridgeHUp_L, HIGH); // pin 5
    digitalWrite(BridgeHDown_R, HIGH);  // pin 4


    Serial.print("El joystick se mueve derecha a: ");
    Serial.println(JoystickY);
  }

  if (JoystickX < -20 && ultimoEstadoX != -20) {

    // Hacia la izquierda

    RemoteXY_delay(1500);
    
    digitalWrite(BridgeHDown_L, HIGH); // pin 2
    digitalWrite(BridgeHUp_R, LOW); // pin 12

    Serial.print("El joystick se mueve izquierda a: ");
    Serial.println(JoystickX);
  }

  if (JoystickX > -20 && JoystickY < 20){

    //Hacia alante e izquierda
    
    digitalWrite(BridgeHDown_L, HIGH); // pin 2
    digitalWrite(BridgeHUp_L, HIGH); // pin 5

  }

  /*
  if (JoystickX > 20 && JoystickY < 20){

    //Hacia alante y derecha

    RemoteXY_delay(1500);

    digitalWrite(BridgeHDown_R, HIGH);  // pin 4
    digitalWrite(BridgeHUp_R, HIGH); // pin 12
  }
  
  if (JoystickX > 20 && JoystickY < -20){

    //Hacia atras y derecha

    RemoteXY_delay(1500);

  }

  if (JoystickX > -20 && JoystickY < -20){

    //Hacia atras e izquierda

    RemoteXY_delay(1500);

  }
  */

  ultimoEstadoY = JoystickY;  // Actualiza el último estado solo si hay un cambio
  ultimoEstadoX = JoystickX;
}

void Intermitentes_Bz (){

  // Funcion para manipular la aplicacion de intermitentes y buzzer del carrito //

  int ultimoEstadoInt = 0; // Almacena el ultimo estado del Intermitente
  int ultimoEstadoBuzzer = 0; 

  if (Int_Button == 1 && ultimoEstadoInt == 0) {

    ultimoEstadoInt = 1;
    digitalWrite(INT_L, HIGH);
    digitalWrite(INT_R, HIGH);
    Serial.println("Las intermitents han sido activadas.");
  } else if (RemoteXY.Intermitentes_1 == 0 && ultimoEstadoBuzzer == 1) {
    
    ultimoEstadoInt = 0;
    digitalWrite(INT_L, LOW);
    digitalWrite(INT_R, LOW);
    Serial.println("Las intermitents se han desactivado.");
  }

  if (Buzzer_Button == 1 && ultimoEstadoBuzzer == 0) {

    ultimoEstadoBuzzer = 1;
    digitalWrite(BZ1, HIGH);
    Serial.println("¡El claxon esta sonando!");
  }   else if (RemoteXY.Buzzer_1 == 0 && ultimoEstadoBuzzer == 1) {  
    
    ultimoEstadoBuzzer = 0;
    digitalWrite(BZ1, LOW);
    Serial.println("El claxon se ha dejado de presionar.");
  }
}
