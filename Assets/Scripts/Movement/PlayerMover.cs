using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float thrustSpeed = 1f;
        [SerializeField] private float rotationSpeed = 1f;

        private Rigidbody _rigidbody;
        private float _thrustInput;
        private float _rotationInput;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            ManageThrust();
            ManageRotation();
        }

        private void ManageThrust()
        {
            _rigidbody.AddRelativeForce(new Vector3(0f, _thrustInput * thrustSpeed * Time.deltaTime, 0f));
        }

        private void ManageRotation()
        {
            _rigidbody.freezeRotation = true;
            transform.Rotate(new Vector3(0f, 0f, -_rotationInput * rotationSpeed * Time.deltaTime));
            _rigidbody.freezeRotation = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX |
                                     RigidbodyConstraints.FreezeRotationY | 
                                     RigidbodyConstraints.FreezePositionZ;
        }

        private void OnThrust(InputValue value)
        {
            _thrustInput = value.Get<float>();
        }

        private void OnRotate(InputValue value)
        {
            _rotationInput = value.Get<float>();
        }
    }
}
