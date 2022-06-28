using UnityEngine;

namespace Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        
        public void TakeDamage(int value)
        {
            health -= value;
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
