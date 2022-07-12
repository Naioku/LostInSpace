using Core;
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
            FindObjectOfType<GameManager>().LoadNextLevel();
        }
    }
}
