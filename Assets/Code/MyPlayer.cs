using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace Assets.Code
{
    public class MyPlayer : MonoBehaviour
    {
        public float Speed = 20f;

        private bool _inputA, _inputD, _inputW, _inputS;
        private NavMeshAgent _agent;

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = Speed;
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
    }
}
