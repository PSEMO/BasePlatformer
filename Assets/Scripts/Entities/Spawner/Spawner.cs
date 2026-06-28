using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerSO data;
    [SerializeField] private GameObject prefabToSpawn;
    
    private float timer;

    private void Start()
    {
        timer = data.InitialDelay;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Spawn();
            timer += data.SpawnInterval; 
        }
    }

    private void Spawn()
    {
        Instantiate(prefabToSpawn, transform.position, transform.rotation);
    }
}
