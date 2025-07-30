// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityTask1
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _buttonText;
        [SerializeField] private Transform _target;

        [Header("Auto Mode Settings")]
        [SerializeField] private float _autoFullRotationTime;

        [Header("Manual Mode Settings")]
        [SerializeField] private float _manualModeSpeed;
        [SerializeField] private float _manualModeDeceleration;

        private const string ManualModeButtonText = "ManualMode";
        private const string AutoModeButtonText = "AutoMode";

        private bool _isAutoMode;
        private Tween _autoModeTween;
        private InputAction _cameraMove;
        private GameObject _targetPivot;

        private float _currentRotationVelocity;

        private void Start()
        {
            if (_target == null)
            {
                Debug.LogError("Target is not assigned!");
                return;
            }

            _targetPivot = new GameObject("Target");
            _targetPivot.transform.position = _target.transform.position;

            transform.LookAt(_targetPivot.transform);
            transform.SetParent(_targetPivot.transform);

            _cameraMove = InputSystem.actions.FindAction("CameraMove");

            _buttonText.text = ManualModeButtonText;
            _isAutoMode = false;
        }

        private void Update()
        {
            if (!_isAutoMode)
                HandleManualMode();
        }

        public void SwitchMode()
        {
            _isAutoMode = !_isAutoMode;

            if (_isAutoMode)
                StartAutoMode();
            else
                StopAutoMode();
        }

        private void HandleManualMode()
        {
            var rotationInput = _cameraMove.ReadValue<float>();
            var targetVelocity = rotationInput * _manualModeSpeed;

            _currentRotationVelocity = Mathf.Lerp(_currentRotationVelocity, targetVelocity,
                Time.deltaTime * (rotationInput != 0 ? _manualModeSpeed : _manualModeDeceleration));

            if (Mathf.Abs(_currentRotationVelocity) > 0.1f)
                _targetPivot.transform.Rotate(0, _currentRotationVelocity * Time.deltaTime, 0);
        }

        private void StopAutoMode()
        {
            _buttonText.text = ManualModeButtonText;

            KillTweenIfIsActive();
        }

        private void StartAutoMode()
        {
            _currentRotationVelocity = 0;
            
            _buttonText.text = AutoModeButtonText;

            KillTweenIfIsActive();

            _autoModeTween = _targetPivot.transform.DORotate(new Vector3(0, -360, 0), _autoFullRotationTime,
                    RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        }

        private void KillTweenIfIsActive()
        {
            if (_autoModeTween != null && _autoModeTween.IsActive())
                _autoModeTween.Kill();
        }

        private void OnDestroy()
        {
            KillTweenIfIsActive();
        }
    }
}