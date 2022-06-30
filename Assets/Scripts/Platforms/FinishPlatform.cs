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
            print("Level completed!");
        }
    }
}
