using UnityEngine;

namespace Movement
{
    public class LightMover : MonoBehaviour
    {
        void Start()
        {
        
        }

        void Update()
        {
            Manage2DMotion();
        }

        private void Manage2DMotion()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                if (!IsRaycastArea(hit.transform.gameObject)) continue;
                
                transform.LookAt(hit.point);
            }
        }

        private static bool IsRaycastArea(GameObject gameObj)
        {
            return gameObj.tag.Equals("RaycastArea");
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
