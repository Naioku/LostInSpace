using Core;
using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private int damageValue = 100;

        private void OnCollisionEnter(Collision collision)
        {
            var gameObj = collision.gameObject;
            if (!FindObjectOfType<GameplayData>().CollisionStateOn ||
                !gameObj.tag.Equals("Player")) return;

            var health = gameObj.GetComponent<Health>();
            if (health == null)
            {
                UnityEngine.Debug.LogError("No Health component!");
                return;
            }
            
            health.TakeDamage(damageValue);
        }
    }
}
