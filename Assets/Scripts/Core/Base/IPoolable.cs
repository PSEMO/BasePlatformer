namespace PSEMO.Core
{
    public interface IPoolable
    {
        public abstract string GroupName { get; set; }

        public abstract void ResetObject();
    }
}