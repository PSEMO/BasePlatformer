using System;

namespace PSEMO.Events
{
    public static class PersistenceEvents
    {
        public static event Action OnGameSave;
        public static void InvokeGameSave() => OnGameSave?.Invoke();

        public static event Action OnGameSaveDelete;
        public static void InvokeGameSaveDelete() => OnGameSaveDelete?.Invoke();
    }
}