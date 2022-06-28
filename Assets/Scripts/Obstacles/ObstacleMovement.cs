using UnityEngine;

namespace Obstacles
{
    public class ObstacleMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 movementVector;
        [SerializeField] [Range(0f, 1f)] private float movementFactor;
        [SerializeField] private float period = 2f;

        private Vector3 _startingPosition;

        private void Start()
        {
            _startingPosition = transform.position;
        }

        private void Update()
        {
            float cycles = Time.time / period; // frame independent because of Time.time;
            const float tau = Mathf.PI * 2;
            float rawSinWave = Mathf.Sin(tau * cycles);

            movementFactor = (rawSinWave + 1f) / 2f;
            
            Vector3 offset = movementVector * movementFactor;
            transform.position = _startingPosition + offset;
        }
    }
}
