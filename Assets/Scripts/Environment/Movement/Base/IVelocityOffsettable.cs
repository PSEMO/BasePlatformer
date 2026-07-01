namespace PSEMO.Environment.Movement
{
    public interface IVelocityOffsettable
    {
        void AddVelocityOffset(IMover offsetter);
        void RemoveVelocityOffset(IMover offsetter);
    }
}