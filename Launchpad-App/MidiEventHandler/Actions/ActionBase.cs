namespace MidiEventHandler.Events;

public abstract class ActionBase
{
    protected Action Callback;

    public ActionBase()
    {
        Callback = GetAction();
    }

    protected abstract Action GetAction();

    public virtual void Execute()
    {
        Callback();
    }
}