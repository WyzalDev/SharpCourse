// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System.Linq;
using UnityEngine;
using Core.UI.Views;

namespace Core.UI
{
    public class PageManager : ViewManager<Page>
    {
        [Header("Starting view Settings")]
        [SerializeField] private Page _startingView;

        private static PageManager _instance;

        protected void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            base.Start();

            if (_startingView != null)
                Show(_startingView);
        }

        public static bool TryGetView<TPage>(out TPage view) where TPage : Page
        {
            view = _instance._views.FirstOrDefault(x => x is TPage) as TPage;

            return view is not null;
        }

        public static void Show<TPage>(object data = null) where TPage : Page
        {
            if (!TryGetView(out TPage view))
                return;

            _instance.Show(view, data);
        }

        public static void ShowLast()
        {
            if (_instance._history.Count <= 0)
                return;

            _instance.ShowLast(_instance._history.Pop());
        }
    }
}