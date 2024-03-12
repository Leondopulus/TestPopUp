using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class UISingleChoicePanel : MonoBehaviour
    {
        [SerializeField] private UISingleChoiceButton[] buttons;

        public event Action<int> SomeButtonClick; 

        private UISingleChoiceButton _selectedButton;

        private void Start()
        {
            if (buttons != null)
            {
                buttons[0].Activate(true);
                _selectedButton = buttons[0];

                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].weight = i;
                    buttons[i].Selected += OnButtonClick;
                }
            }
        }

        private void OnButtonClick(UISingleChoiceButton selected)
        {
            _selectedButton.Activate(false);
            _selectedButton = selected;
            _selectedButton.Activate(true);
            
            if (buttons != null)
            {
                int weight = 100 / buttons.Length * selected.weight;
                SomeButtonClick?.Invoke(weight);
            }
        }
        
        
    }
}