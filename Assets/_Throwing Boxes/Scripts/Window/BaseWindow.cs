using UnityEngine;

namespace Throwing_Boxes
{
    public class BaseWindow : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }

        public void Bind(object args)
        {
            if (args == null)
                return;

            OnBind(args);
        }

        protected virtual void OnBind(object args) { }

        protected virtual void OnShow() { }

        protected virtual void OnHide() { }
    }
}