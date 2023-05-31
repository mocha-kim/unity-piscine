using UnityEngine;

namespace Module01.Interaction
{
    public class PlatformMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;
        [SerializeField] private Vector3[] waypoints = new Vector3[2];
        private int _waypointIndex = 0;

        void Update()
        {
            if (Vector3.Distance(waypoints[_waypointIndex], transform.position) <= 0)
            {
                _waypointIndex++;
                _waypointIndex %= 2;
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[_waypointIndex]
                , _speed * Time.deltaTime);
        }
    }
}