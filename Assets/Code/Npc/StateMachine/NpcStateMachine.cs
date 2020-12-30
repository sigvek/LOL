using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Npc.StateMachine
{
    public class NpcStateMachine
    {
        private INpcState _state;

        public NpcStateMachine(INpcState state)
        {
            ChangeState(state);
        }

        public void ChangeState(INpcState newState)
        {
            _state?.Exit();
            _state = newState;
            _state?.Enter();
        }

        public void Update()
        {
            _state?.Execute();
        }
    }
}
