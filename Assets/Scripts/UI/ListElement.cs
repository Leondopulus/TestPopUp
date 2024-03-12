using UnityEngine;

public class ListElement : MonoBehaviour
{
    [SerializeField] private UIToggleButton checkbox;
    [SerializeField] private UIToggleButton viewButton;
    
    private Shape _shape;

    public ListElement Init(Shape shape)
    {
        _shape = shape;
        viewButton.ToggleActivate += _shape.SetView;
        return this;
    }

    public UIToggleButton CheckBox => checkbox;
    public UIToggleButton ViewButton => viewButton;
    public Shape ShapeObject => _shape;
}
