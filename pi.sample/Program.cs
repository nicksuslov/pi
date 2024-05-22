// See https://aka.ms/new-console-template for more information
using System.Device.Gpio;
using System.Device.I2c;
using System.Drawing;
using Iot.Device.CharacterLcd;

// dotnet publish --self-contained --runtime linux-arm64 --configuration Release -p:PublishReadyToRun=true -o ./release

// Console.WriteLine("Blinking LED. Press Ctrl+C to end.");

// int redPin = 18;
// int greenPin = 23;
// int whitePin = 24;

// using var controller = new GpioController();

// controller.OpenPin(redPin, PinMode.Output);
// controller.OpenPin(greenPin, PinMode.Output);
// controller.OpenPin(whitePin, PinMode.Output);

// var loopCount = 1;

// while (true)
// { 
//     Console.WriteLine($"loop {loopCount++}");
//     controller.Write(redPin, PinValue.High);
//     Thread.Sleep(100);
//     controller.Write(redPin, PinValue.Low);
//     Thread.Sleep(100);

//     controller.Write(greenPin, PinValue.High);
//     Thread.Sleep(100);
//     controller.Write(greenPin, PinValue.Low);
//     Thread.Sleep(100);

//     controller.Write(whitePin, PinValue.High);
//     Thread.Sleep(100);
//     controller.Write(whitePin, PinValue.Low);
//     Thread.Sleep(100);
// }

// using Lcd1602 lcd = new Lcd1602(registerSelectPin: 22, enablePin: 17, dataPins: new int[] { 25, 24, 23, 18 });
// lcd.Clear();
// lcd.Write("Hello World");

var i2cLcdDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x3E));
var i2cRgbDevice = I2cDevice.Create(new I2cConnectionSettings(busId: 1, deviceAddress: 0x60));
using LcdRgb lcd = new LcdRgb(new Size(16, 2), i2cLcdDevice, i2cRgbDevice);
{
    lcd.Write("Hello World!");
    lcd.SetBacklightColor(Color.Azure);
}