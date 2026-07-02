using System;
using UnityEngine;

namespace PSEMO.Events
{
    public static class PlayerEvents
    {
        public static event Action OnPlayerDeath;
        public static void InvokePlayerDeath() => OnPlayerDeath?.Invoke();

        public static event Action<Vector3> OnCheckPointReached;
        public static void InvokeCheckPointReached(Vector3 newSpawnPos) => OnCheckPointReached?.Invoke(newSpawnPos);
    }
}