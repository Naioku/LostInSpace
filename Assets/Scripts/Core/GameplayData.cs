using UnityEngine;

namespace Core
{
    public class GameplayData : MonoBehaviour
    {
        public int PlayerMaxHealth => 100;
        public bool CollisionStateOn { get; set; } = true;
        
        public void Start()
        {
            CollisionStateOn = true;
        }
    }
}