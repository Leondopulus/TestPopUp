using UnityEngine;

namespace DefaultNamespace
{
    public class CameraRotator : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform cameraZoomTransform;
        [SerializeField] private Transform firstViewHolder;
        [SerializeField] private Transform thirdViewHolder;
        
        [Header("Settings")]
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float scrollSpeed = 500f;

        private Transform _playerTransform;
        private void Update()
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                RotateCamera();
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                Zoom();
            }
        }

        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public void SetCameraView(bool firstView)
        {
            cameraTransform.position = firstView ? firstViewHolder.position : thirdViewHolder.position;
        }

        private void RotateCamera()
        {
            var x = Input.GetAxis("Mouse X");
            var y = Input.GetAxis("Mouse Y");
            _playerTransform.eulerAngles += rotationSpeed * new Vector3(-y, x, 0);
        }

        public Vector3 translation;

        private void Zoom()
        {
            translation = new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"));
            cameraZoomTransform.Translate(translation * scrollSpeed * Time.deltaTime);
        }
    }
}