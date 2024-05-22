// See https://aka.ms/new-console-template for more information
using System.Device.Gpio;

// dotnet publish --self-contained --runtime linux-arm64 --configuration Release -p:PublishReadyToRun=true -o ./release

Console.WriteLine("Blinking LED. Press Ctrl+C to end.");

int redPin = 18;
int greenPin = 23;
int whitePin = 24;

using var controller = new GpioController();

controller.OpenPin(redPin, PinMode.Output);
controller.OpenPin(greenPin, PinMode.Output);
controller.OpenPin(whitePin, PinMode.Output);

var loopCount = 1;

while (true)
{ 
    Console.WriteLine($"loop {loopCount++}");
    controller.Write(redPin, PinValue.High);
    Thread.Sleep(100);
    controller.Write(redPin, PinValue.Low);
    Thread.Sleep(100);

    controller.Write(greenPin, PinValue.High);
    Thread.Sleep(100);
    controller.Write(greenPin, PinValue.Low);
    Thread.Sleep(100);

    controller.Write(whitePin, PinValue.High);
    Thread.Sleep(100);
    controller.Write(whitePin, PinValue.Low);
    Thread.Sleep(100);
}