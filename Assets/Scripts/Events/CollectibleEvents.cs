using System;
using System.Collections.Generic;
using PSEMO.Environment.Functionality.Collectible;

namespace PSEMO.Events
{
    public static class CollectibleEvents
    {
        public static event Action<string> OnCollectibleCollected;
        public static void InvokeCollectibleCollected(string group) => OnCollectibleCollected?.Invoke(group);

        public static event Action<Dictionary<string, int>, Dictionary<string, CollectibleSO>> OnCollectibleCountsUpdated;
        public static void InvokeCollectibleCountsUpdated(Dictionary<string, int> counts, Dictionary<string, CollectibleSO> groupData) => OnCollectibleCountsUpdated?.Invoke(counts, groupData);
    }
}