using System.Collections.Generic;
using UnityEngine;

public class CollectibleTracker : MonoBehaviour
{
    public static CollectibleTracker Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        InitializeCollectibles();
    }

    [SerializeField] private AllCollectibleSOs allCollectibles;
    public AllCollectibleSOs AllCollectibles => allCollectibles;

    public Dictionary<string, int> CollectedCounts { get; private set; } = new();
    public Dictionary<string, CollectibleSO> GroupData { get; private set; } = new();

    private void InitializeCollectibles()
    {
        foreach (var collectible in allCollectibles.collectibles)
        {
            if (!GroupData.ContainsKey(collectible.group))
            {
                GroupData[collectible.group] = collectible;
            }
        }
    }

    private void OnEnable()
    {
        Events.OnCollectibleCollected += HandleCollectibleCollected;
    }

    private void OnDisable()
    {
        Events.OnCollectibleCollected -= HandleCollectibleCollected;
    }

    private void HandleCollectibleCollected(string group)
    {
        if (CollectedCounts.ContainsKey(group))
        {
            CollectedCounts[group]++;
        }
        else
        {
            CollectedCounts[group] = 1;
        }
    }

    public int GetCount(string group)
    {
        return CollectedCounts.TryGetValue(group, out int count) ? count : 0;
    }
}