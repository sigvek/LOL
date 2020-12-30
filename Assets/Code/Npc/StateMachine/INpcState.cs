using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Npc.StateMachine
{
    public interface INpcState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}
