using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllCollectibleDatas", menuName = "SO/AllCollectibles")]
public class AllCollectibleSOs : ScriptableObject
{
    public List<CollectibleSO> collectibles;
}
