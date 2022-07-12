using UnityEngine;

namespace Core
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip damageClip;
        [SerializeField] private float damageVolume = 0.5f;
        [SerializeField] private AudioClip destroyClip;
        [SerializeField] private float destroyVolume = 0.5f;


        public void PlayDamageClip(Vector3 position)
        {
            if (damageClip == null) return;

            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(
                damageClip,
                new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 2f), 
                damageVolume);
        }
        
        public void PlayDestroyClip(Vector3 position)
        {
            if (destroyClip == null) return;
        
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(
                destroyClip,
                new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 2f), 
                destroyVolume);
        }
    }
}
