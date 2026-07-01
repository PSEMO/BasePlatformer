using System;
using UnityEngine;

namespace PSEMO.Persistence.Data
{
    [Serializable]
    public class PlayerSaveData
    {
        public Vector3 playerPosition;
        public Vector3 playerRespawnPosition;
    }
}