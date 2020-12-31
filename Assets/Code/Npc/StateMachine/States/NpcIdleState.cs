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
    public class NpcIdleState : NpcStateBase, INpcState
    {
        private NavMeshAgent _agent;
        private int _enemyLayer;
        private Transform _nearestEnemy;

        public NpcIdleState(MinionBase owner): base(owner)
        {
           
        }

        public void Enter()
        {
            _agent = Owner.GetComponent<NavMeshAgent>();
            _agent.destination = Owner.MoveTarget.position;
            _agent.isStopped = false;

            _enemyLayer = LayerMask.NameToLayer("SouthTeam");
        }

        public void Execute()
        {
            FindEnemies();
        }

        public void Exit()
        {
            _agent.isStopped = true;
        }

        private void FindEnemies()
        {
            Collider[] hitColliders = Physics.OverlapSphere(
                Owner.transform.position, Owner.AwareRadius, 1 << _enemyLayer);
            float minimumDistance = Mathf.Infinity;
            foreach (Collider collider in hitColliders)
            {
                float distance = Vector3.Distance(Owner.transform.position, collider.transform.position);
                if (distance < minimumDistance)
                {
                    minimumDistance = distance;
                    _nearestEnemy = collider.transform;
                }
            }

            if (_nearestEnemy != null)
            {
                Owner.StateMachine.ChangeState(new NpcAttackState(Owner, _nearestEnemy));
            }
        }
    }
}
