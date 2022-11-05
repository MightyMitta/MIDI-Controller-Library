namespace MidiEventHandler.Events;

public class MidiButtonEventHandler
{
    private MidiButtonListener Listener;
    private Dictionary<int, List<ActionBase>> Actions;

    public MidiButtonEventHandler(MidiButtonListener listener)
    {
        Listener = listener;
        Actions = new Dictionary<int, List<ActionBase>>();
        Listener.MidiButtonPressed += OnButtonPressed;
    }

    private void OnButtonPressed(object sender, MidiButtonPressedEventArgs e)
    {
        if (Actions.TryGetValue(e.Button, out var actions))
        {
            if (e.State == 127)
            {
                actions.ForEach(a => a.Execute());
            }
        }
    }

    public void Register(int button, ActionBase action)
    {
        if (Actions.TryGetValue(button, out var actions))
        {
            actions.Add(action);
        }
        else
        {
            Actions.Add(button, new List<ActionBase> { action });
        }
    }

    public void Unregister<T>(int button, T action) where T: ActionBase
    {
        if (Actions.TryGetValue(button, out var actions))
        {
            actions.Remove(action);
        }
    }

    public void Unregister<T>(int button) where T : ActionBase
    {
        if (Actions.TryGetValue(button, out var actions))
        {
            actions.RemoveAll(a => a.GetType() == typeof(T));
        }
    }
}