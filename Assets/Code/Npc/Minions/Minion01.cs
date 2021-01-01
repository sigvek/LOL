using Assets.Code.Damage;
using Assets.Code.Npc.StateMachine;
using Assets.Code.Npc.StateMachine.States;
using Assets.Code.Npc.StateMachine.States.NpcStates;

namespace Assets.Code.Npc.Minions
{
    public class Minion01 : MinionBase
    {
        void Update()
        {
            StateMachine.Update();
        }
    }
}
