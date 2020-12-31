using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Code.UI
{
    public class FloatingInfo : MonoBehaviour
    {
        public float MaxHealth = 1000f;
        public float CurrentHealth = 1000f;

        public Slider HealthBar;

        private Transform _healthBarTransform;
        private Transform _mainCameraTransform;
        private Canvas _canvas;

        private float _tmpValue = 1f;
        private float _targetValue = 0f;

        void Awake()
        {
            _healthBarTransform = transform;
            _mainCameraTransform = Camera.main.transform;
            _canvas = GetComponent<Canvas>();
            _canvas.worldCamera = Camera.main;
        }

        void Start()
        {
            HealthBar.value = 1f;
        }

        void Update()
        {
            _healthBarTransform.LookAt(2 * _healthBarTransform.position - _mainCameraTransform.position);

            if (_tmpValue > _targetValue)
            {
                _tmpValue -= 0.1f;
                //HealthBar.normalizedValue = _tmpValue;
            }
        }

        public void SetHealthBar(float percent)
        {
            HealthBar.value = percent;
            _targetValue = percent;
        }
    }
}
