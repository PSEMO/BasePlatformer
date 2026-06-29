using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour, IResettable
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float distanceToleranceSqr = 0.01f;

    [SerializeField] private List<Transform> waypoints;
    
    private List<Vector3> targetPositions;

    private Vector3 initialPos;
    
    private int currentWaypointIndex = 0;

    void Start()
    {
        initialPos = transform.position;

        targetPositions = new();

        foreach (Transform waypoint in waypoints)
        {
            targetPositions.Add(waypoint.position);
        }
    }

    private void Update()
    {
        Vector3 targetPos = targetPositions[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector3.SqrMagnitude(transform.position - targetPos) <= distanceToleranceSqr)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % targetPositions.Count;
        }
    }

    public void ResetObject()
    {
        currentWaypointIndex = 0;
        transform.position = initialPos;
    }
}