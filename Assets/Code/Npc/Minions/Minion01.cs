using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Npc.StateMachine;
using Assets.Code.Npc.StateMachine.States;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code.Npc.Minions
{
    public class Minion01 : MinionBase
    {
        void Start()
        {
            

            StateMachine = new NpcStateMachine(new NpcIdleState(this));
        }

        void Update()
        {
            StateMachine.Update();
        }
    }
}
