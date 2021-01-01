using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Npc.Minions;
using Assets.Code.Player;
using UnityEngine;

namespace Assets.Code.Npc.StateMachine.States
{
    public abstract class PlayerStateBase : IState
    {
        public PlayerBase Owner { get; set; }

        protected PlayerStateBase(PlayerBase owner)
        {
            Owner = owner;
        }

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}
