using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Damage;
using Assets.Code.Player;
using Assets.Code.Npc.Minions;
using UnityEngine;

namespace Assets.Code.Attacks
{
    public class PlayerAutoAttackProjectile : MonoBehaviour
    {
        public PlayerBase Owner;
        public Transform AttackTarget;

        private Vector3 _direction;

        void Start()
        {
            transform.localScale = Vector3.one * 4;
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
                AttackTarget.GetComponentInParent<IDamagable>().TakeDamage(Owner.DamageData);

                Destroy(gameObject);
            }
        }
    }
}
