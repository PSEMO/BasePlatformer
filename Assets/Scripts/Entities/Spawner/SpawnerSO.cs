using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerData", menuName = "SO/Spawner")]
public class SpawnerSO : ScriptableObject
{
    [Tooltip("Time in seconds between each spawn.")]
    public float SpawnInterval = 2f;
    
    [Tooltip("Time in seconds before the first spawn.")]
    public float InitialDelay = 0f;
}
