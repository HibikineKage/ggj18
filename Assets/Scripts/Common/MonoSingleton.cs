using UnityEngine;

namespace ggj2018
{
    public class MonoSingleton <T> : MonoBehaviour
        where T : MonoSingleton<T>
    {
        #region unity message handlers

        void Awake()
        {
            Instance = (T)this;
            SubAwake();
        }

        void OnDestroy()
        {
            SubOnDestroy();
            Instance = null;
        }

        #endregion

        protected virtual void SubAwake()
        {
        }

        protected virtual void SubOnDestroy()
        {
        }

        public static T Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = GameObject.FindObjectOfType<T>();
                }
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }

        private static T _Instance;
    }
}
