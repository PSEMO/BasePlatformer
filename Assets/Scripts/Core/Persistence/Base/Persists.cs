using UnityEngine;

namespace PSEMO.Core.Persistence
{
    public abstract class Persists : MonoBehaviour
    {
        [Tooltip("Unique ID for this specific object in the scene.")]
        [ContextMenuItem("Generate New ID", nameof(GenerateId))]
        public string persistenceId = System.Guid.NewGuid().ToString();

        public void GenerateId()
        {
            persistenceId = System.Guid.NewGuid().ToString();
        }

        public abstract void LoadData(string jsonData);
        public abstract string SaveData();
    }
}