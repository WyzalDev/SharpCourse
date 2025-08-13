// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Core.UI.Views;

namespace Core.UI
{
    public class PopupManager : ViewManager<Popup>
    {
        private static PopupManager _instance;

        [Header("Fade Settings")]
        [SerializeField] private Image _notifyFade;
        [SerializeField] [Range(0, 1)] private float _fadePower;
        [SerializeField] private float _fadeDuration;

        protected void Awake()
        {
            _instance = this;
        }

        public static bool TryGetView<TPopup>(out TPopup view) where TPopup : Popup
        {
            view = _instance._views.FirstOrDefault(x => x is TPopup) as TPopup;

            return view is not null;
        }

        public static void ShowNotification<TPopup>(string message) where TPopup : Popup, new()
        {
            if (!TryGetView(out TPopup view))
                return;

            _instance._notifyFade.gameObject.SetActive(true);

            _instance._notifyFade.DOFade(_instance._fadePower, _instance._fadeDuration)
                .SetEase(Ease.InOutSine)
                .OnComplete(() => { _instance.Show(view, message); });
        }

        public static void HideNotification()
        {
            if (_instance._history.Count <= 0)
                return;

            _instance.ShowLast(_instance._history.Pop());

            _instance._notifyFade.DOFade(0, _instance._fadeDuration)
                .SetEase(Ease.InOutSine)
                .OnComplete(() => { _instance._notifyFade.gameObject.SetActive(false); });
        }
    }
}