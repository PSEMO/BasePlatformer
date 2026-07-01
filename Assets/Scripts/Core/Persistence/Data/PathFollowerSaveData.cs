using UnityEngine;

namespace PSEMO.Core.Persistence
{
    [System.Serializable]
    public class PathFollowerSaveData
    {
        public Vector3 position;
        public int currentWaypointIndex;
        public Vector3 targetPos;
    }
}