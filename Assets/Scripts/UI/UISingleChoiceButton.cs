using System;

namespace DefaultNamespace
{
    public class UISingleChoiceButton : UIToggleButton
    {
        public int weight;
        
        public event Action<UISingleChoiceButton> Selected;

        public override void Activate()
        {
            Selected?.Invoke(this);
        }
        
        
    }
}