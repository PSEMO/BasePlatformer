namespace PSEMO.Core.StateMachine
{
    public interface IState
    {
        void OnEnter();
        void OnEnter(IState previousState);

        void Update();

        void FixedUpdate();

        void OnExit();
        void OnExit(IState nextState);
    }
}