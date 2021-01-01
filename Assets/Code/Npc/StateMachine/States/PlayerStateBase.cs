using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Npc.Minions;
using UnityEngine;

namespace Assets.Code.Npc.StateMachine.States
{
    public abstract class PlayerStateBase : IState
    {
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}
