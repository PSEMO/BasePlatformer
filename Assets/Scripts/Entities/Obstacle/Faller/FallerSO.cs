using UnityEngine;

[CreateAssetMenu(fileName = "FallerData", menuName = "SO/Obstacle/Faller")]
public class FallerSO : ScriptableObject
{
    public float maxSpeed = 20f;
    public float gravity = 9.8f;
}