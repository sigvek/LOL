using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Npc.StateMachine;
using UnityEngine;

namespace Assets.Code.Npc.Minions
{
    public class MinionBase : MonoBehaviour
    {
        public Transform MoveTarget;
        public float AwareRadius = 10f;
        public float AttackRadius = 5f;
        public float TimeToStopAttack = 2f;

        public NpcStateMachine StateMachine;
    }
}
