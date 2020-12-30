using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Damage;
using Assets.Code.Npc.Minions;
using UnityEngine;

namespace Assets.Code.Attacks
{
    public class NpcAutoAttackProjectile : MonoBehaviour
    {
        public MinionBase Owner;
        public Transform AttackTarget;

        private Vector3 _direction;

        void Start()
        {
            Debug.Log($"TargetTransform: {AttackTarget.position}");
        }

        void Update()
        {
            if(!AttackTarget)
                return;

            _direction = (AttackTarget.position - transform.position).normalized;
            transform.position += _direction * Owner.DamageData.ProjectileSpeed * Time.deltaTime;
        }
    }
}
