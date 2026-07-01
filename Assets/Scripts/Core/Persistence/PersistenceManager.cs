using System.Collections.Generic;
using System.IO;
using PSEMO.Core.Management;
using UnityEngine;

namespace PSEMO.Persistence
{
    [System.Serializable]
    public class SerializableDictionary
    {
        public List<string> keys = new();
        public List<string> values = new();
    }

    public class PersistenceManager : MonoBehaviour
    {
        [Header("File Storage Config")]
        [SerializeField] private static string fileName = "data.gameName";

        private List<Persists> dataPersistenceObjects;

        void Start() 
        {
            dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }

        void OnEnable()
        {
            Events.OnGameSave += SaveTheGame;
            Events.OnGameSaveDelete += DeleteGameData;
        }

        void OnDisable()
        {
            Events.OnGameSave -= SaveTheGame;
            Events.OnGameSaveDelete -= DeleteGameData;
        }

        public static bool HasGameData()
        {
            string fullPath = Path.Combine(Application.persistentDataPath, fileName);
            return File.Exists(fullPath);
        }

        public void LoadGame()
        {
            SerializableDictionary loadedDict = LoadFromFile();

            Dictionary<string, string> gameData = new();
            if (loadedDict != null)
            {
                for (int i = 0; i < loadedDict.keys.Count; i++)
                {
                    gameData[loadedDict.keys[i]] = loadedDict.values[i];
                }
            }
            else
            {
                Debug.Log("No data was found. Initializing data to defaults.");
            }

            foreach (Persists dataPersistenceObj in dataPersistenceObjects)
            {
                if (gameData.TryGetValue(dataPersistenceObj.persistenceId, out string jsonData))
                {
                    dataPersistenceObj.LoadData(jsonData);
                }
            }
        }

        void DeleteGameData()
        {
            string fullPath = Path.Combine(Application.persistentDataPath, fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                Debug.Log("Game data deleted.");
            }
        }

        void SaveTheGame()
        {
            SerializableDictionary dictToSave = new();

            foreach (Persists dataPersistenceObj in dataPersistenceObjects)
            {
                dictToSave.keys.Add(dataPersistenceObj.persistenceId);
                dictToSave.values.Add(dataPersistenceObj.SaveData());
            }

            SaveToFile(dictToSave);
        }

        private List<Persists> FindAllDataPersistenceObjects()
        {
            IEnumerable<Persists> dataPersistenceObjects = FindObjectsByType<Persists>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            return new List<Persists>(dataPersistenceObjects);
        }

        private SerializableDictionary LoadFromFile() 
        {
            string fullPath = Path.Combine(Application.persistentDataPath, fileName);
            SerializableDictionary loadedData = null;
            if (File.Exists(fullPath)) 
            {
                try 
                {
                    string dataToLoad = "";
                    using (FileStream stream = new(fullPath, FileMode.Open))
                    {
                        using StreamReader reader = new(stream);
                        dataToLoad = reader.ReadToEnd();
                    }
                    loadedData = JsonUtility.FromJson<SerializableDictionary>(dataToLoad);
                }
                catch (System.Exception e) 
                {
                    Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
                }
            }
            return loadedData;
        }

        private void SaveToFile(SerializableDictionary data) 
        {
            string fullPath = Path.Combine(Application.persistentDataPath, fileName);
            try 
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                string dataToStore = JsonUtility.ToJson(data, true);
                using (FileStream stream = new(fullPath, FileMode.Create))
                {
                    using StreamWriter writer = new(stream);
                    writer.Write(dataToStore);
                }
            }
            catch (System.Exception e) 
            {
                Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
            }
        }
    }
}