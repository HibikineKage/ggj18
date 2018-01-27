using UnityEngine;

namespace ggj2018
{
    public class TimeManager : MonoSingleton<TimeManager>
    {
        event System.Action OnTimeup;

        private bool _isStarted;
        private float _remainSec = GameConstants.GameLimitSec;

        public int RemainSec {
            get {
                return (int)_remainSec;
            }
        }

        public void StartGame()
        {
            _isStarted = true;
        }

        void Update()
        {
            if (_isStarted) {
                _remainSec -= Time.deltaTime;
                if (_remainSec <= 0f) {
                    _remainSec = 0f;
                    OnTimeup();
                    _isStarted = false;
                }
            }
        }
    }
}

