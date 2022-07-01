using UnityEngine;

namespace Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        
        private GameObject _UICanvas;
        
        private void Start()
        {
            _UICanvas = GameObject.FindWithTag("UI");
            _UICanvas.GetComponent<UI.Health>().SetHealth(health);
        }
        
        public void TakeDamage(int value)
        {
            health -= value;
            _UICanvas.GetComponent<UI.Health>().SetHealth(health);
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
