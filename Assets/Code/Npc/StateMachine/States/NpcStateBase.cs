using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Npc.Minions;
using UnityEngine;

namespace Assets.Code.Npc.StateMachine.States
{
    public class NpcStateBase
    {
        public MinionBase Owner { get; set; }

        public NpcStateBase(MinionBase owner)
        {
            Owner = owner;
        }
    }
}
