using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace ggj2018
{
    public class GameScene : SceneBase<GameScene>
    {
        [SerializeField]
        private CharcterBehavior[] _charcters=new CharcterBehavior[GameConstants.PlayerNum];

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


			SceneBackgroundMusic (SceneManager.GetActiveScene());

        }

        void Update()
        {
            var timeManager = TimeManager.Instance;
            if (timeManager.IsStarted) {
                var remainSec = TimeManager.Instance.RemainSec;
                var min = remainSec / 60;
                var sec = remainSec % 60;
                // TODO: アロケート走るけどGameJamなので・・・
                if(_remainTime!=null)_remainTime.text  = min + ":" + sec;
            }
        }

        void OnTimeup()
        {   
            var dataManager = ScenesDataManager.Instance;
            int rank = dataManager.GetCurrentRank();
            for (int i = 0; i < GameConstants.PlayerNum; i++) {
                if (!dataManager.IsPlayerGoal(i)) {
                    dataManager.AddStageResult(i, new ggj2018.ScenesDataManager.PlayerStageResult(){
                        Rank = rank,
                        RemainTime = 0,
                        BadScore = ScoreManager.Instance.GetBadScore(i),
                    });
                }
            }
                
            if (dataManager.IsAllPlayerGoal()) {
                dataManager.NextStage();
                LoadNextScene();
            }
        }
            
        void LoadNextScene()
        {
            int loadingSceneIndex = SceneUtility.GetBuildIndexByScenePath(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(loadingSceneIndex + 1);
        } 

		public void SceneBackgroundMusic(Scene scene)
		{
			Debug.Log (scene.name);
			if (scene.name == "Stage1") {
				BgmManager.Instance.PlayMainBGM ();
				BgmManager.Instance.PlayStage1Background ();
				Debug.Log ("hello");
			} else if (scene.name == "Stage2") {
				BgmManager.Instance.PlayStage2Background ();
			} else if (scene.name == "Stage3") {
				BgmManager.Instance.PlayStage3Background ();
			} else if (scene.name == "Stage4") {
				BgmManager.Instance.PlayStage4Background ();
			} else if (scene.name == "Result") {
				BgmManager.Instance.PlayResultBGM ();
			} else if (scene.name == "Title") {
				BgmManager.Instance.PlayStartMenu ();
			} else {
				BgmManager.Instance.PlayCharSelect ();
			}
		}
    }
}
