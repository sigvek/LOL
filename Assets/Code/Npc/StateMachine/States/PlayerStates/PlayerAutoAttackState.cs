using UnityEngine;

namespace Assets.Code.Npc.StateMachine.States.PlayerStates
{
    public class PlayerAutoAttackState : PlayerStateBase
    {
        public override void Enter()
        {
            Debug.Log($"Player auto attack started!");
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
