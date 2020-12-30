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

            Move();
            DealDamage();
        }

        private void Move()
        {
            _direction = (AttackTarget.position - transform.position);
            transform.position += _direction.normalized * Owner.DamageData.ProjectileSpeed * Time.deltaTime;
        }

        private void DealDamage()
        {
            if (_direction.magnitude <= .5f)
            {
                Debug.Log($"Magnitude: {_direction.magnitude}");
                // Gi skade
                AttackTarget.GetComponentInParent<IDamagable>().TakeDamage(Owner.DamageData);

                Destroy(gameObject);
            }
        }
    }
}
