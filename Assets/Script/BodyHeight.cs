using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class BodyHeight : MonoBehaviour
    {
        [SerializeField] private List<FootMover> targetfootpoints;

        void Update()
        {
            CalculateHeight();
        }

        void CalculateHeight()
        {
            float sum = 0f;

            for (int i = 0; i < targetfootpoints.Count; i++)
            {
                sum += targetfootpoints[i].newTarget.y;
            }
            float newHeight = sum / targetfootpoints.Count;
            transform.position = new Vector3(transform.position.x, newHeight + 2.5f, transform.position.z);
        }
    }
}
