using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PopUpController : UIActiveElement
    {
        [SerializeField] private Button popUpButton;
        [SerializeField] private Transform body;
        [SerializeField] private ListElement listElementPrefab;
        [SerializeField] private UIHeaderPanel header;

        private ListElement[] _shapeElements;

        public void Init(Shape[] shapes)
        {
            _shapeElements = new ListElement[shapes.Length];
            for (int i = 0; i < shapes.Length; i++)
            {
                _shapeElements[i] = Instantiate(listElementPrefab, body).Init(shapes[i]);
                _shapeElements[i].CheckBox.ToggleActivate += OnCheckBoxButton;
                _shapeElements[i].ViewButton.ToggleActivate += OnViewButton;
            }
            
            popUpButton.onClick.AddListener(Activate);

            header.CapacityPanel.SomeButtonClick += OnCapacityChange;
            header.AllViewButton.ToggleActivate += OnAllViewButton;
            header.AllCheckBoxButton.ToggleActivate += OnAllCheckBoxButton;
            
            header.AllViewButton.Activate(true);
        }

        public override void Activate(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Activate()
        {
            Activate(!gameObject.activeSelf);
        }

        private void OnCapacityChange(int weight)
        {
            foreach (var shapeElement in _shapeElements)
            {
                if (shapeElement.CheckBox.IsActive)
                {
                    shapeElement.ShapeObject.SetCapacity(weight);    
                }
            }
        }

        private void OnAllViewButton(bool active)
        {
            foreach (var shapeElement in _shapeElements)
            {
                shapeElement.ViewButton.Activate(active);
            }
        }

        private void OnViewButton(bool active)
        {
            if (header.AllViewButton.IsActive != active)
            {
                bool isAllViewActive = true;
                foreach (var shapeElement in _shapeElements)
                {
                    if (shapeElement.ViewButton.IsActive != active)
                    {
                        isAllViewActive &= shapeElement.ViewButton.IsActive == active;
                    }
                }
                active = isAllViewActive ? active : !active;
                
                header.AllViewButton.Activate(active);
            }
        }

        private void OnAllCheckBoxButton(bool active)
        {
            foreach (var shapeElement in _shapeElements)
            {
                shapeElement.CheckBox.Activate(active);
            }
        }

        private void OnCheckBoxButton(bool active)
        {
            if (header.AllCheckBoxButton.IsActive != active)
            {
                bool isAllCheckBoxActive = true;
                foreach (var shapeElement in _shapeElements)
                {
                    if (shapeElement.ViewButton.IsActive != active)
                    {
                        isAllCheckBoxActive &= shapeElement.ViewButton.IsActive == active;
                    }
                }
                active = isAllCheckBoxActive ? active : !active;
                header.AllCheckBoxButton.Activate(active);
            }
        }
        

    }
}