using Assets.Code.Npc.Minions;
using UnityEngine;

namespace Assets.Code.Npc.StateMachine.States.NpcStates
{
    public class NpcAttackState : NpcStateBase
    {
        private float _lastAttackTime = 0;

        public NpcAttackState(MinionBase owner, Transform attackTarget): base(owner)
        {
            owner.AttackTarget = attackTarget;
        }

        public override void Enter()
        {
            _lastAttackTime = Time.time;

            Owner.Shoot();
        }

        public override void Execute()
        {
            ShouldStopAttacking();
        }

        public override void Exit()
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
