﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Code.Attacks;
using Assets.Code.Damage;
using Assets.Code.Npc.Minions;
using Assets.Code.Npc.StateMachine;
using Assets.Code.Npc.StateMachine.States;
using Assets.Code.Npc.StateMachine.States.PlayerStates;
using Assets.Code.UI;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code.Player
{
    public class PlayerBase : MonoBehaviour, IDamagable
    {
        private NavMeshAgent _agent;
        private FloatingInfo _floatingInfo;
        private bool _inputA, _inputD, _inputW, _inputS;

        public DamageData DamageData;
        public PlayerAutoAttackProjectile Projectile;
        public Transform AttackTarget;
        public float Speed = 20f;
        public float MaxHealth = 1000f;
        public float CurrentHealth = 1000f;
        public StateMachine<PlayerStateBase> StateMachine;

        void Start()
        {
            DamageData = new DamageData() { BaseDamage = 200f, ProjectileSpeed = 30f };

            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = Speed;
            _floatingInfo = GetComponentInChildren<FloatingInfo>();
            _floatingInfo.SetHealthBar(1f);

            StateMachine = new StateMachine<PlayerStateBase>(new PlayerIdleState(this));
        }

        void Update()
        {
            Movement();
            MouseMovement();
            StateMachine.Update();
        }

        private void MouseMovement()
        {
            if (Input.GetMouseButton(0))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, 100))
                {
                    _agent.destination = hit.point;
                    StateMachine.ChangeState(new PlayerIdleState(this));
                    _agent.isStopped = false;
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, 100))
                {
                    var target = hit.transform.GetComponent<MinionBase>();
                    // Traff minion
                    if (target != null && (AttackTarget == null || target.transform != AttackTarget.transform))
                    {
                        Debug.Log($"Traff: {target.CurrentHealth} hp!");
                        StateMachine.ChangeState(new PlayerAutoAttackState(this, target.transform));
                        _agent.isStopped = true;
                    }
                    else // traff IKKE minion
                    {
                        StateMachine.ChangeState(new PlayerIdleState(this));
                        AttackTarget = null;
                        _agent.isStopped = false;
                        _agent.destination = hit.point;
                    }
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

            Debug.Log($"Player takes {damageData.BaseDamage} damage! Now {CurrentHealth} hp");
        }
    }
}
