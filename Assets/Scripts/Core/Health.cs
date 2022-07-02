using UnityEngine;

namespace Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        [SerializeField] private ParticleSystem damageVFX;
        [SerializeField] private ParticleSystem destructionVFX;
        
        private void Start()
        {
            FindObjectOfType<UI.Health>().SetHealth(health);
        }
        
        public void TakeDamage(int value, Vector3 position)
        {
            Instantiate(damageVFX, position, Quaternion.identity).Play();
            health -= value;
            FindObjectOfType<UI.Health>().SetHealth(health);
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Vector3 rocketPosition = transform.position;
            Destroy(gameObject);
            Instantiate(destructionVFX, rocketPosition, Quaternion.identity).Play();
            FindObjectOfType<GameManager>().RestartLevel();
        }
    }
}
