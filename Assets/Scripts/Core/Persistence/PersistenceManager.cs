using System.Collections.Generic;
using System.IO;
using UnityEngine;
using PSEMO.Events;

namespace PSEMO.Core.Persistence
{
    public class PersistenceManager : MonoBehaviour
    {
        private List<Persists> dataPersistenceObjects;

        void Start() 
        {
            dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }

        void OnEnable()
        {
            PersistenceEvents.OnGameSave += SaveTheGame;
            PersistenceEvents.OnGameSaveDelete += DeleteGameData;
        }

        void OnDisable()
        {
            PersistenceEvents.OnGameSave -= SaveTheGame;
            PersistenceEvents.OnGameSaveDelete -= DeleteGameData;
        }

        void LoadGame()
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
            string fullPath = Path.Combine(Application.persistentDataPath, Env.FileName);
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
                if (dictToSave.keys.Contains(dataPersistenceObj.persistenceId))
                {
                    Debug.LogWarning($"Duplicate ID found:");
                    Debug.LogWarning($"{dataPersistenceObj.persistenceId}");
                    Debug.LogWarning($"{dataPersistenceObj.gameObject.name}");
                    Debug.LogWarning("------------------------------------");
                    continue;
                }
                dictToSave.keys.Add(dataPersistenceObj.persistenceId);
                dictToSave.values.Add(dataPersistenceObj.SaveData());
            }

            SaveToFile(dictToSave);
        }

        List<Persists> FindAllDataPersistenceObjects()
        {
            IEnumerable<Persists> dataPersistenceObjects = FindObjectsByType<Persists>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            return new List<Persists>(dataPersistenceObjects);
        }

        SerializableDictionary LoadFromFile() 
        {
            string fullPath = Path.Combine(Application.persistentDataPath, Env.FileName);
            SerializableDictionary loadedData = null;
            if (File.Exists(fullPath)) 
            {
                try 
                {
                    string dataToLoad = File.ReadAllText(fullPath);
                    loadedData = JsonUtility.FromJson<SerializableDictionary>(dataToLoad);
                }
                catch (System.Exception e) 
                {
                    Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
                }
            }
            return loadedData;
        }

        void SaveToFile(SerializableDictionary data) 
        {
            string fullPath = Path.Combine(Application.persistentDataPath, Env.FileName);
            try 
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                string dataToStore = JsonUtility.ToJson(data, true);
                File.WriteAllText(fullPath, dataToStore);
            }
            catch (System.Exception e) 
            {
                Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
            }
        }
    }
}