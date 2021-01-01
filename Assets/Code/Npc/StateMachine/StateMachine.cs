using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Npc.StateMachine
{
    public class StateMachine<T> where T : IState
    {
        private IState _state;

        public StateMachine(IState state)
        {
            ChangeState(state);
        }

        public void ChangeState(IState newState)
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
