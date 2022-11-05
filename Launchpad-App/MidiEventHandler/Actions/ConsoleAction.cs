namespace MidiEventHandler.Events;

public class ConsoleAction : ActionBase
{
    private string Message;

    public ConsoleAction(string message)
    {
        Message = message;
    }

    protected override Action GetAction()
    {
        return () => Console.WriteLine(Message);
    }

    public void UpdateMessage(string message)
    {
        Message = message;
    }
}