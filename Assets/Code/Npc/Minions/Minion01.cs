using Assets.Code.Damage;
using Assets.Code.Npc.StateMachine;
using Assets.Code.Npc.StateMachine.States;

namespace Assets.Code.Npc.Minions
{
    public class Minion01 : MinionBase
    {
        void Start()
        {
            DamageData = new DamageData() {BaseDamage = 100f, ProjectileSpeed = 30f};

            StateMachine = new NpcStateMachine(new NpcIdleState(this));
        }

        void Update()
        {
            StateMachine.Update();
        }
    }
}
