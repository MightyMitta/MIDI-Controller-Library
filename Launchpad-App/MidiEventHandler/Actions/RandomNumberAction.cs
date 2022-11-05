using MidiEventHandler.Events;

namespace MidiEventHandler.Actions
{
    public class RandomNumberAction : ActionBase
    {
        private int Min, Max;

        public RandomNumberAction(int min, int max) 
        {
            Min = min;
            Max = max;
        }
        
        protected override Action GetAction()
        {
            return () => Console.WriteLine(new Random().Next(Min, Max + 1));
        }
    }
}
