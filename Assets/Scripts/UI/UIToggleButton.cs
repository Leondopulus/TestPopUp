using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleButton : UIActiveElement
{
    [SerializeField] protected Transform selected;
    [SerializeField] protected Button button;

    public event Action<bool> ToggleActivate;

    private bool _isActive;

    private void Start()
    {
        if(button) button.onClick.AddListener(Activate);
    }

    public override void Activate(bool active)
    {
        if (_isActive == active) return;
        
        _isActive = active;
        selected.gameObject.SetActive(active);

        ToggleActivate?.Invoke(active);
    }

    public virtual void Activate()
    {
        Activate(!_isActive);
    }

    public bool IsActive => _isActive;
}
