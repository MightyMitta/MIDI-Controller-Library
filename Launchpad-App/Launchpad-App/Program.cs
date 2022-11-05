using MidiEventHandler.Actions;
using MidiEventHandler.Events;

namespace Launchpad_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listener = new MidiButtonListener();
            var handler = new MidiButtonEventHandler(listener);

            listener.OpenDevice(0);

            handler.Register(16, new ConsoleAction("Button 16 pressed"));
            handler.Register(17, new RandomNumberAction(1, 10));
        }
    }
}