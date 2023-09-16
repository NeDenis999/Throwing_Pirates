using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private SerializablePair<WindowType, BaseWindow>[] _windows;

        private void Start()
        {
            Show(WindowType.Gameplay);
        }

        public void Show(WindowType type, object args = null, bool hideOther = true)
        {
            if (hideOther)
                HideAll();

            foreach (var pair in _windows)
            {
                if (pair.Key == type)
                {
                    pair.Value.Show();
                    pair.Value.Bind(args);
                }
            }
        }

        public void HideAll()
        {
            foreach (var pair in _windows)
                pair.Value.Hide();
        }

        public bool IsShow(WindowType type)
        {
            foreach (var pair in _windows)
            {
                if (pair.Key == type)
                {
                    return pair.Value.gameObject.activeSelf;
                }
            }

            throw new Exception($"Окно {type} не найдено");
        }

        public void Hide(WindowType type)
        {
            foreach (var pair in _windows)
            {
                if (pair.Key == type)
                {
                    pair.Value.Hide();
                    return;
                }
            }

            throw new Exception($"Окно {type} не найдено");
        }
    }
}