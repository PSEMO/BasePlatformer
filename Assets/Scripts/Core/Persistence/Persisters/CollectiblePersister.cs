using UnityEngine;
using PSEMO.Environment.Functionality.Collectible;

namespace PSEMO.Core.Persistence
{
    [RequireComponent(typeof(Collectible))]
    public class CollectiblePersister : Persists
    {
        Collectible ctx;

        void Awake()
        {
            ctx = GetComponent<Collectible>();
        }

        public override void LoadData(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData)) return;

            CollectibleSaveData data = JsonUtility.FromJson<CollectibleSaveData>(jsonData);
            
            ctx.isCollected = data.isCollected;
            if (ctx.isCollected)
            {
                ctx.HandleContact();
            }
        }

        public override string SaveData()
        {
            CollectibleSaveData data = new()
            {
                isCollected = ctx.isCollected
            };
            return JsonUtility.ToJson(data);
        }
    }
}
