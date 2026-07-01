using PSEMO.Player;
using UnityEngine;
using PSEMO.Persistence.Data;

namespace PSEMO.Persistence
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerPersister : Persists
    {
        PlayerController ctx;

        void Awake()
        {
            ctx = GetComponent<PlayerController>();
        }

        public override void LoadData(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData)) return;

            PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(jsonData);
            
            ctx.transform.position = data.playerPosition;
            ctx.respawnPos = data.playerRespawnPosition;
        }

        public override string SaveData()
        {
            PlayerSaveData data = new()
            {
                playerPosition = ctx.transform.position,
                playerRespawnPosition = ctx.respawnPos
            };
            return JsonUtility.ToJson(data);
        }
    }
}