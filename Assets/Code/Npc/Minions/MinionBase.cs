using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Attacks;
using Assets.Code.Damage;
using Assets.Code.Npc.StateMachine;
using Assets.Code.Npc.StateMachine.States;
using Assets.Code.Npc.StateMachine.States.NpcStates;
using Assets.Code.UI;
using UnityEngine;

namespace Assets.Code.Npc.Minions
{
    public class MinionBase : MonoBehaviour, IDamagable
    {
        public Transform MoveTarget;
        public float AwareRadius = 10f;
        public float AttackRadius = 5f;
        public float TimeToStopAttack = 2f;
        public NpcAutoAttackProjectile Projectile;
        public Transform AttackTarget;
        public DamageData DamageData;

        public float Speed = 20f;
        public float MaxHealth = 1000f;
        public float CurrentHealth = 1000f;
        private FloatingInfo _floatingInfo;

        public StateMachine<NpcStateBase> StateMachine;

        public void Start()
        {
            DamageData = new DamageData() { BaseDamage = 100f, ProjectileSpeed = 30f };

            StateMachine = new StateMachine<NpcStateBase>(new NpcIdleState(this));
            _floatingInfo = GetComponentInChildren<FloatingInfo>();
            _floatingInfo.SetHealthBar(1f);
        }

        public void Shoot()
        {
            var projectile = Projectile;
            projectile.Owner = this;
            projectile.AttackTarget = AttackTarget;
            var clone = Instantiate(projectile, transform);
        }

        public void TakeDamage(DamageData damageData)
        {
            CurrentHealth -= damageData.BaseDamage;
            _floatingInfo.SetHealthBar(CurrentHealth / MaxHealth);

            Debug.Log($"Minion takes {damageData.BaseDamage} damage! Now {CurrentHealth} hp");
        }
    }
}
