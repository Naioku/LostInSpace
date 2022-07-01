using UI;
using UnityEngine;

namespace Debug
{
    public class HealthSlider : MonoBehaviour
    {
        [SerializeField] private int addPoints;
        [SerializeField] private int subtractPoints;
        
        private GameObject _UICanvas;

        private void Start()
        {
            _UICanvas = GameObject.FindWithTag("UI");
        }

        private void OnAddHealthPoints()
        {
            _UICanvas.GetComponent<Health>().AddHealth(addPoints);
        }

        private void OnTakeHealthPoints()
        {
            _UICanvas.GetComponent<Health>().SubtractHealth(subtractPoints);
        }
    }
}
