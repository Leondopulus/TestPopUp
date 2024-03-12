using DefaultNamespace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CameraRotator cameraRotator;
    [SerializeField] private Mover mover;

    private Shape _selectedShape;
    private Vector3 _lastPos;
    private Quaternion _lastRot;

    public void Init(Shape[] shapes)
    {
        cameraRotator.Init(playerTransform);
        mover.Init(playerTransform);

        foreach (var shape in shapes)
        {
            shape.GetClicked += GetShape;
        }
    }

    private void GetShape(Shape shape)
    {
        if(_selectedShape == shape)
        {
            _selectedShape = null;

            mover.enabled = true;
            playerTransform.position = _lastPos;
            playerTransform.rotation = _lastRot;
            cameraRotator.SetCameraView(true);
        }
        else
        {
            if (_selectedShape == null)
            {
                _lastPos = playerTransform.position;
                _lastRot = playerTransform.rotation;
            }
            
            _selectedShape = shape;
            
            mover.enabled = false;
            playerTransform.position = _selectedShape.transform.position;
            cameraRotator.SetCameraView(false);
        }
    }

}
