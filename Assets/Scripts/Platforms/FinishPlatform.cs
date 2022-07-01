using Core;
using Movement;
using UI;
using UnityEngine;

namespace Platforms
{
    public class FinishPlatform : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.tag.Equals("Player")) return;

            Finish();
        }

        private void Finish()
        {
            FindObjectOfType<Messages>().FadeInMessage("Level completed!");
            FindObjectOfType<PlayerMover>().enabled = false;
            FindObjectOfType<GameplayData>().CollisionStateOn = false;
            FindObjectOfType<GameManager>().LoadNextLevel();
        }
    }
}
