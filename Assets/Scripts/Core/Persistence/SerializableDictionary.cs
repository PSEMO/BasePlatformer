using System.Collections.Generic;

namespace PSEMO.Core.Persistence
{
    [System.Serializable]
    public class SerializableDictionary
    {
        public List<string> keys = new();
        public List<string> values = new();
    }
}