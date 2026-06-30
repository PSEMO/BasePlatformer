using System;
using UnityEngine;

public static class Events
{
    public static event Action OnPlayerDeath;
    public static void InvokePlayerDeath() => OnPlayerDeath?.Invoke();

    public static event Action<Vector3> OnCheckPointReached;
    public static void InvokeCheckPointReached(Vector3 newSpawnPos) => OnCheckPointReached?.Invoke(newSpawnPos);

    public static event Action<string> OnCollectibleCollected;
    public static void InvokeCollectibleCollected(string group) => OnCollectibleCollected?.Invoke(group);
}
