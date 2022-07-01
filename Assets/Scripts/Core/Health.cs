using UnityEngine;

namespace Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        
        private void Start()
        {
            FindObjectOfType<UI.Health>().SetHealth(health);
        }
        
        public void TakeDamage(int value)
        {
            health -= value;
            FindObjectOfType<UI.Health>().SetHealth(health);
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().RestartLevel();
        }
    }
}
