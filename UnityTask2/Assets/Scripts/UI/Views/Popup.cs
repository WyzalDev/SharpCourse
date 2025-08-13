// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Core.UI.Views
{
    public class Popup : View
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _message;

        public override void Initialize()
        {
            _backButton.onClick.AddListener(OnCloseButton);
        }

        public override void Show(object data = null)
        {
            base.Show(data);

            if (data is string viewData)
                _message.text = viewData;
        }

        private void OnCloseButton()
        {
            PopupManager.HideNotification();
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveListener(OnCloseButton);
        }
    }
}