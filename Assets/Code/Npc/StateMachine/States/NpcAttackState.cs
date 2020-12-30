using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Npc.Minions;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code.Npc.StateMachine.States
{
    public class NpcAttackState : NpcStateBase, INpcState
    {
        private float _lastAttackTime = 0;

        public NpcAttackState(MinionBase owner): base(owner)
        {
           
        }

        public void Enter()
        {
            Debug.Log($"Starter Attack state");
            _lastAttackTime = Time.time;
        }

        public void Execute()
        {
            ShouldStopAttacking();
        }

        public void Exit()
        {
            Debug.Log($"Slutter Attack state");
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
