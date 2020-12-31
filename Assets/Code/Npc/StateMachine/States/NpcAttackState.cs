using Assets.Code.Attacks;
using Assets.Code.Damage;
using Assets.Code.Npc.Minions;
using UnityEngine;

namespace Assets.Code.Npc.StateMachine.States
{
    public class NpcAttackState : NpcStateBase, INpcState
    {
        private float _lastAttackTime = 0;

        public NpcAttackState(MinionBase owner, Transform attackTarget): base(owner)
        {
            owner.AttackTarget = attackTarget;
        }

        public void Enter()
        {
            _lastAttackTime = Time.time;

            Owner.Shoot();
        }

        public void Execute()
        {
            ShouldStopAttacking();
        }

        public void Exit()
        {
        }

        private void ShouldStopAttacking()
        {
            if (Time.time - _lastAttackTime >= Owner.TimeToStopAttack)
            {
                Owner.StateMachine.ChangeState(new NpcIdleState(Owner));
            }
        }
    }
}
