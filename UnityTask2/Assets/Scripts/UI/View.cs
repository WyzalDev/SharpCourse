// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using UnityEngine;

namespace Core.UI
{
    public abstract class View : MonoBehaviour
    {
        public abstract void Initialize();

        public virtual void Show(object data = null)
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}