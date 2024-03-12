using UnityEngine;

namespace DefaultNamespace
{
    public class UIHeaderPanel : MonoBehaviour
    {
        [SerializeField] private UISingleChoicePanel panel;
        [SerializeField] private UIToggleButton allCheckBoxButton;
        [SerializeField] private UIToggleButton allViewButton;

        public UISingleChoicePanel CapacityPanel => panel;
        public UIToggleButton AllCheckBoxButton => allCheckBoxButton;
        public UIToggleButton AllViewButton => allViewButton;
    }
}