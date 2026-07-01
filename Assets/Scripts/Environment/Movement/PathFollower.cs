using System.Collections.Generic;
using UnityEngine;
using PSEMO.Environment.Functionality;

namespace PSEMO.Environment.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PathFollower : MonoBehaviour, IMover, IPoolable
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float distanceToleranceSqr = 0.01f;

        [SerializeField] private List<Transform> waypoints;
        private List<Vector3> targetPositions;
    
        [HideInInspector] public int currentWaypointIndex = 0;

        private Vector3 directionalSpeed = Vector3.zero;
        [HideInInspector] public Vector3 targetPos = Vector3.zero;

        private Rigidbody2D rb;

        Vector3 initialPosition;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            initialPosition = transform.position;
        }

        void Start()
        {
            targetPositions = new();

            foreach (Transform waypoint in waypoints)
            {
                targetPositions.Add(waypoint.position);
            }

            targetPos = targetPositions[currentWaypointIndex];
        }

        private void Update()
        {
            if (Vector3.SqrMagnitude(transform.position - targetPos) <= distanceToleranceSqr)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % targetPositions.Count;
                targetPos = targetPositions[currentWaypointIndex];
            }
        }

        void FixedUpdate()
        {
            directionalSpeed = speed * (targetPos - transform.position).normalized;
            rb.linearVelocity = directionalSpeed;
        }

        public Vector2 GetVelocity()
        {
            return directionalSpeed;
        }

        public void ResetObject()
        {
            directionalSpeed = Vector3.zero;
            rb.linearVelocity = Vector2.zero;
            currentWaypointIndex = 0;
            targetPos = targetPositions[0];
            transform.position = initialPosition;
        }
    }
}