using UnityEngine;
using PSEMO.Core.StateMachine;

namespace PSEMO.Player
{

    public abstract class PlayerBaseState : BaseState<PlayerController>
    {
        protected static readonly int IdleAnimHash = Animator.StringToHash("IdleAnim");
        protected static readonly int RunAnimHash = Animator.StringToHash("WalkAnim");
        protected static readonly int DashAnimHash = Animator.StringToHash("DashAnim");
        protected static readonly int JumpAnimHash = Animator.StringToHash("JumpAnim");
        protected static readonly int FallAnimHash = Animator.StringToHash("FallAnim");

        protected PlayerBaseState(PlayerController _ctx, Animator _animator) : base(_ctx, _animator)
        {
        }
    }
}