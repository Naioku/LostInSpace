using UI;
using UnityEngine;

namespace Debug
{
    public class HealthSlider : MonoBehaviour
    {
        [SerializeField] private int addPoints;
        [SerializeField] private int subtractPoints;

        private void OnAddHealthPoints()
        {
            FindObjectOfType<Health>().AddHealth(addPoints);
        }

        private void OnTakeHealthPoints()
        {
            FindObjectOfType<Health>().SubtractHealth(subtractPoints);
        }
    }
}
