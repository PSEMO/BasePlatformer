using UnityEngine;

public abstract class BaseState<TController> : IState where TController : IController
{
    protected readonly TController ctx;
    protected readonly Animator animator;

    protected BaseState(TController _ctx, Animator _animator)
    {
        ctx = _ctx;
        animator = _animator;
    }

    public virtual void OnEnter()
    {
        // noop
    }

    public virtual void Update()
    {
        // noop
    }

    public virtual void FixedUpdate()
    {
        // noop
    }

    public virtual void OnExit()
    {
        // noop
    }
}