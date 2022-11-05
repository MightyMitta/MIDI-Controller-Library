namespace MidiEventHandler.Events;

public class MidiButtonPressedEventArgs
{
    public int Button { get; set; }
    public int State { get; set; }

    public MidiButtonPressedEventArgs(int button, int state)
    {
        Button = button;
        State = state;
    }
}