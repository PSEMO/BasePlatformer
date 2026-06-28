using UnityEngine;

[CreateAssetMenu(fileName = "PathFollowerData", menuName = "SO/Obstacle/PathFollower")]
public class PathFollowerSO : ScriptableObject
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Config")]
    public float distanceToleranceSqr = 0.01f;
}