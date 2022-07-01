using System.Collections.Generic;
using UnityEngine;

namespace Light
{
    public class PulsatingLight : MonoBehaviour
    {
        [SerializeField] private List<UnityEngine.Light> lightObjs = new();
        [SerializeField] [Range(0f, 1f)] private float pulseOffset;
        [SerializeField] private float period = 2f;
        [SerializeField] [Range(0f, 1f)] private float pulseFactor;
        
        private readonly List<float> _basicIntensities = new();

        private void Start()
        {
            foreach (var obj in lightObjs)
            {
                _basicIntensities.Add(obj.intensity);
            }
        }

        private void Update()
        {
            float cycles = Time.time / period + pulseOffset; // frame independent because of Time.time;
            const float tau = Mathf.PI * 2;
            float rawSinWave = Mathf.Sin(tau * cycles);

            pulseFactor = (rawSinWave + 1f) / 4f + 0.5f;

            for (int i = 0; i < lightObjs.Count; i++)
            {
                lightObjs[i].intensity = _basicIntensities[i] * pulseFactor;
            }
        }
    }
}
