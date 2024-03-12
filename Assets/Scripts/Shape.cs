using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shape : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Material material;
    [SerializeField] private Renderer rend;
    
    public event Action<Shape> GetClicked;
    public void OnPointerClick(PointerEventData eventData)
    {
        GetClicked?.Invoke(this);
    }

    public void SetCapacity(int weight)
    {
        var materialColor = material.color;
        materialColor.a = weight * 0.01f;
        rend.material.color = materialColor;
    }

    public void SetView(bool active)
    {
        rend.enabled = active;
    }
}
