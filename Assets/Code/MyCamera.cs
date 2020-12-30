using UnityEngine;

namespace Assets.Code
{
    public class MyCamera : MonoBehaviour
    {
        public Transform TargeTransform;
        public float Distance = 10;

        void Update()
        {
            transform.position = new Vector3
            {
                x = TargeTransform.position.x + Distance,
                y = TargeTransform.position.y + Distance,
                z = TargeTransform.position.z - Distance
            };

            transform.LookAt(TargeTransform);
        }
    }
}
