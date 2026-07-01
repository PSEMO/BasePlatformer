using UnityEngine;

namespace PSEMO.Persistence.Data
{
    [System.Serializable]
    public class PathFollowerSaveData
    {
        public Vector3 position;
        public int currentWaypointIndex;
        public Vector3 targetPos;
    }
}