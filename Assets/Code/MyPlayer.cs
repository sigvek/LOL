using System;
using System.Runtime.CompilerServices;
using Assets.Code.Damage;
using Assets.Code.UI;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code
{
    public class MyPlayer : MonoBehaviour, IDamagable
    {
        public float Speed = 20f;
        public float MaxHealth = 1000f;
        public float CurrentHealth = 1000f;

        private bool _inputA, _inputD, _inputW, _inputS;
        private NavMeshAgent _agent;
        private FloatingInfo _floatingInfo;

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = Speed;
            _floatingInfo = GetComponentInChildren<FloatingInfo>();
            _floatingInfo.SetHealthBar(1f);
        }

        void Update()
        {
            Movement();
            MouseMovement();
        }

        private void MouseMovement()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    _agent.destination = hit.point;
                }
            }
        }

        private void Movement()
        {
            _inputA = Input.GetKey(KeyCode.A);
            _inputD = Input.GetKey(KeyCode.D);
            _inputW = Input.GetKey(KeyCode.W);
            _inputS = Input.GetKey(KeyCode.S);

            if (_inputA)
            {
                transform.Translate(Vector3.left * Time.deltaTime * Speed);
            }

            if (_inputD)
            {
                transform.Translate(Vector3.right * Time.deltaTime * Speed);
            }

            if (_inputW)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            }

            if (_inputS)
            {
                transform.Translate(Vector3.back * Time.deltaTime * Speed);
            }
        }

        public void TakeDamage(DamageData damageData)
        {
            CurrentHealth -= damageData.BaseDamage;
            _floatingInfo.SetHealthBar(CurrentHealth / MaxHealth);

            Debug.Log($"Player takes {damageData.BaseDamage} damage! Now {CurrentHealth} hp");
        }
    }
}
