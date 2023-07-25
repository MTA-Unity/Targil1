using UnityEngine;

namespace Targil1
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Transform _characterTransform;
        [SerializeField] private Rigidbody _characterRigidbody;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;
        
        private Vector3 _newPosition;
        private Vector3 _newRotation;
    
        private void Start()
        {
            _newPosition = _characterTransform.position;
            _newRotation = _characterTransform.rotation.eulerAngles;
        }

        private void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            
            var horizontalMovementDelta = horizontalInput * _movementSpeed * Time.deltaTime;
            var verticalMovementDelta = verticalInput * _movementSpeed * Time.deltaTime;
            
            _newPosition = _newPosition +
                           _characterTransform.TransformDirection(Vector3.right) * horizontalMovementDelta +
                           _characterTransform.TransformDirection(Vector3.forward) * verticalMovementDelta;
            
            var rotationInput = Input.GetAxis("Mouse X");
            var rotationDelta = rotationInput * _rotationSpeed;
            _newRotation += Vector3.up * rotationDelta;
        }

        void FixedUpdate()
        {
            _characterRigidbody.MovePosition(_newPosition);
            _characterRigidbody.MoveRotation(Quaternion.Euler(_newRotation));
        }
    }
}
