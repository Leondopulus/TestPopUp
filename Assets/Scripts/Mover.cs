using UnityEngine;

namespace DefaultNamespace
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private Transform _playerTransform;
        private Vector3 _moveVector;

        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        private void Update()
        {
            MovePos();
        }

        private void MovePos()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _playerTransform.Translate(movement * speed * Time.fixedDeltaTime);
        }
    }
}