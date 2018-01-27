using UnityEngine;
using UnityEngine.UI;

namespace ggj2018
{
    public class GameScene : SceneBase<GameScene>
    {
        [SerializeField]
        private CharcterBehavior[] _charcters;

        [SerializeField]
        private Text _remainTime;

        void Start()
        {
            for (var i = 0; i < GameConstants.PlayerNum; i++) 
            {
                _charcters[i].Setup(i);
            }

            var timeManager = TimeManager.Instance;
            timeManager.OnTimeup += OnTimeup;
            timeManager.StartGame();
        }

        void Update()
        {
            var timeManager = TimeManager.Instance;
            if (timeManager.IsStarted) {
                var remainSec = TimeManager.Instance.RemainSec;
                var min = remainSec / 60;
                var sec = remainSec % 60;
                // TODO: アロケート走るけどGameJamなので・・・
                _remainTime.text  = min + ":" + sec;
            }
        }

        void OnTimeup()
        {
        }
    }
}