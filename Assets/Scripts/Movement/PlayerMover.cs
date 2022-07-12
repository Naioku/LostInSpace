using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float thrustSpeed = 1f;
        [SerializeField] private float rotationSpeed = 1f;
        [SerializeField] private ParticleSystem mainEngineVFX;
        [SerializeField] private ParticleSystem leftEngineVFX;
        [SerializeField] private ParticleSystem rightEngineVFX;

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
            ManageMainEngineParticles();
            ManageRotation();
            ManageLeftAndRightEngineParticles();
            ManageEngineSFX();
        }

        private void OnDisable()
        {
            mainEngineVFX.Stop();
            leftEngineVFX.Stop();
            rightEngineVFX.Stop();
            GetComponent<AudioSource>().Stop();
        }

        private void ManageThrust()
        {
            _rigidbody.AddRelativeForce(new Vector3(0f, _thrustInput * thrustSpeed * Time.deltaTime, 0f));
        }

        private void ManageMainEngineParticles()
        {
            if (_thrustInput != 0f)
            {
                if (!mainEngineVFX.isPlaying)
                {
                    mainEngineVFX.Play();
                }
            }
            else
            {
                mainEngineVFX.Stop();
            }
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

        private void ManageLeftAndRightEngineParticles()
        {
            if (_rotationInput == 1f)
            {
                if (!leftEngineVFX.isPlaying)
                {
                    leftEngineVFX.Play();
                }
            }
            else
            {
                leftEngineVFX.Stop();
            }
            
            if (_rotationInput == -1f)
            {
                if (!rightEngineVFX.isPlaying)
                {
                    rightEngineVFX.Play();
                }
            }
            else
            {
                rightEngineVFX.Stop();
            }
        }

        private void ManageEngineSFX()
        {
            AudioSource engineSFX = GetComponent<AudioSource>();

            if (_thrustInput != 0f ||
                _rotationInput != 0f)
            {
                if (!engineSFX.isPlaying)
                {
                    engineSFX.Play();
                }
            }
            else
            {
                engineSFX.Stop();
            }
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
