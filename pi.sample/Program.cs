// See https://aka.ms/new-console-template for more information
using System.Device.Gpio;

// dotnet publish --self-contained --runtime linux-arm64 --configuration Release -p:PublishReadyToRun=true -o ./release

Console.WriteLine("Blinking LED. Press Ctrl+C to end.");

int ledPin = 18;

using var controller = new GpioController();

controller.OpenPin(ledPin, PinMode.Output);

var loopCount = 1;

while (true)
{ 
    Console.WriteLine($"loop {loopCount++}");
    controller.Write(ledPin, PinValue.High);
    Thread.Sleep(100);
    controller.Write(ledPin, PinValue.Low);
    Thread.Sleep(100);
}