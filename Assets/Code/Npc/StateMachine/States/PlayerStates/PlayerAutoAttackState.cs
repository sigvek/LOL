using Assets.Code.Npc.StateMachine.States.NpcStates;
using Assets.Code.Player;
using UnityEngine;

namespace Assets.Code.Npc.StateMachine.States.PlayerStates
{
    public class PlayerAutoAttackState : PlayerStateBase
    {
        private float _autoAttackCooldown = 1f;
        private float _lastAttackTime = 1f;

        public PlayerAutoAttackState(PlayerBase owner, Transform attackTarget): base(owner)
        {
            owner.AttackTarget = attackTarget;
        }

        public override void Enter()
        {
            Debug.Log($"Angriper...");
            _lastAttackTime = float.MinValue;
        }

        public override void Execute()
        {
            if ((Time.time - _lastAttackTime) >= _autoAttackCooldown)
            {
                Debug.Log($"Skyter...");
                _lastAttackTime = Time.time;
                Owner.Shoot();
            }
        }

        public override void Exit()
        {
        }

        private void ShouldStopAttacking()
        {
            
        }
    }
}
