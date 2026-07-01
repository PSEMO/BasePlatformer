using System;
using UnityEngine;

namespace PSEMO.Core.Persistence
{
    [Serializable]
    public class PlayerSaveData
    {
        public Vector3 playerPosition;
        public Vector3 playerRespawnPosition;
    }
}