using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFollowerController : MonoBehaviour, IResettable
{
    [SerializeField] private PathFollowerSO data;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private List<Vector3> targetPositions;

    private Vector3 initialPos;
    
    private int currentWaypointIndex = 0;

    void Start()
    {
        initialPos = transform.position;

        foreach (Transform waypoint in waypoints)
        {
            targetPositions.Add(waypoint.position);
        }
    }

    private void Update()
    {
        Vector3 targetPos = targetPositions[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPos, data.speed * Time.deltaTime);

        if (Vector3.SqrMagnitude(transform.position - targetPos) <= data.distanceToleranceSqr)
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