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

        public StateMachine(T state)
        {
            ChangeState(state);
        }

        public void ChangeState(T newState)
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
