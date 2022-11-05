using Sanford.Multimedia.Midi;

namespace MidiEventHandler.Events;

public class MidiButtonListener
{
    public EventHandler<MidiButtonPressedEventArgs> MidiButtonPressed;

    private static InputDevice inDevice = null;
    private static SynchronizationContext context;
    public MidiButtonListener()
    {
        if (InputDevice.DeviceCount == 0)
        {
            Console.WriteLine("No MIDI input devices available.");
        }
        else
        {
            try
            {
                context = SynchronizationContext.Current;

                OpenDevice(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void OpenDevice(int deviceId)
    {
        if (inDevice != null)
        {
            inDevice.StopRecording();
        }
        
        try
        {
            inDevice = new InputDevice(deviceId);
            inDevice.StartRecording();
            inDevice.ChannelMessageReceived += HandleChannelMessageReceived;
        }
        catch(InputDeviceException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void HandleChannelMessageReceived(object? sender, ChannelMessageEventArgs e)
    {
        MidiButtonPressed(this, new MidiButtonPressedEventArgs(e.Message.Data1, e.Message.Data2));
    }
}