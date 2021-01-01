﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Npc.Minions;
using UnityEngine;

namespace Assets.Code.Npc.StateMachine.States
{
    public abstract class NpcStateBase : IState
    {
        public MinionBase Owner { get; set; }

        protected NpcStateBase(MinionBase owner)
        {
            Owner = owner;
        }

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}
