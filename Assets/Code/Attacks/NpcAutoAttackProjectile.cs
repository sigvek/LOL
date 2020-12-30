using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Damage;
using UnityEngine;

namespace Assets.Code.Attacks
{
    public class NpcAutoAttackProjectile : MonoBehaviour
    {
        public Transform TargeTransform;
        //public DamageData DamageData;

        private Vector3 _direction;

        void Start()
        {
            Debug.Log($"TargetTransform: {TargeTransform.position}");
        }

        void Update()
        {
            if(!TargeTransform)
                return;

            _direction = (TargeTransform.position - transform.position).normalized;
            transform.position += _direction * 10f * Time.deltaTime;
        }
    }
}
