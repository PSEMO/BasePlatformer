using UnityEngine;
using PSEMO.Environment.Movement;

namespace PSEMO.Core.Persistence
{
    [RequireComponent(typeof(PathFollower))]
    public class PathFollowerPersister : Persists
    {
        PathFollower ctx;

        void Awake()
        {
            ctx = GetComponent<PathFollower>();
        }

        public override void LoadData(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData)) return;

            PathFollowerSaveData data = JsonUtility.FromJson<PathFollowerSaveData>(jsonData);
            
            ctx.transform.position = data.position;
            ctx.currentWaypointIndex = data.currentWaypointIndex;
            ctx.targetPos = data.targetPos;
        }

        public override string SaveData()
        {
            PathFollowerSaveData data = new()
            {
                position = ctx.transform.position,
                currentWaypointIndex = ctx.currentWaypointIndex,
                targetPos = ctx.targetPos
            };
            return JsonUtility.ToJson(data);
        }
    }
}
