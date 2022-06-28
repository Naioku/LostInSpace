using Core;
using UnityEngine;

namespace Collisions
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private int damageValue = 100;

        private void OnCollisionEnter(Collision collision)
        {
            var gameObj = collision.gameObject;
            if (!gameObj.tag.Equals("Player")) return;

            var health = gameObj.GetComponent<Health>();
            if (health == null)
            {
                print("No Health component!");
                return;
            }
            health.TakeDamage(damageValue);
        }
    }
}