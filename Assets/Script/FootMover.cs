using UnityEngine;

namespace Script
{
    public class FootMover : MonoBehaviour
    {
        public Vector3 newTarget { get; set;}
        
        
        [SerializeField] private Transform targetpoint;
        [SerializeField] private float distance;
        [SerializeField] private float maxHeightDistance;
        
        [SerializeField] private float countLerpPos = 0.4f;
        [SerializeField] private float countLerpHeight = 0.5f;
        [SerializeField] private float speed = 5;
        [SerializeField] private float amplitude = 0.4f;
        private float _currenttime = 1f;

        void Start()
        {
            newTarget = targetpoint.position;
        }
        
        void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                Debug.Log("1");
                if (Vector3.Distance(hit.point, targetpoint.position) > distance)
                {
                    _currenttime = 0;
                    Debug.Log("2");
                    newTarget = hit.point;
                }

                if (_currenttime < 1)
                {
                    Debug.Log("3");
                    Vector3 footposition = Vector3.Lerp(targetpoint.position, hit.point, countLerpPos);
                    
                    footposition.y = Mathf.Lerp(footposition.y, hit.point.y, countLerpHeight) + (Mathf.Sin(_currenttime * Mathf.PI) * amplitude);
                    
                    targetpoint.position = footposition;
                    _currenttime += Time.deltaTime * speed;
                }
            }
        }
    }
}
