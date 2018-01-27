using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

namespace ggj2018
{
    public class GameScene : SceneBase<GameScene>
    {
        [SerializeField]
        private CharcterBehavior[] _charcters=new CharcterBehavior[GameConstants.PlayerNum];

        [SerializeField]
        private LetterBehaviour[] _letters=new LetterBehaviour[GameConstants.PlayerNum];

        [SerializeField]
        private RankBehaviour[] _ranks=new RankBehaviour[GameConstants.PlayerNum];

        [SerializeField]
        private Text _remainTime;

        void Start()
        {
            var dataManager = ScenesDataManager.Instance;
            if (!dataManager.IsInitPlayers) {
                // 本体は事前に初期化されるが、シーン直接起動の場合の対応
                dataManager.InitPlayers();
            }

            _charcters = GetComponentsInChildren<CharcterBehavior>();
            for (var i = 0; i < GameConstants.PlayerNum; i++) 
            {
                _charcters[i].Setup(i);
            }

            _letters = GetComponentsInChildren<LetterBehaviour>(includeInactive:true);
            _ranks = GetComponentsInChildren<RankBehaviour>(includeInactive:true);

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

        public void OnGoal(int playerNum)
        {  
            var dataManager = ScenesDataManager.Instance;
            var stage = dataManager.GetPlayerStage(playerNum);
            _letters[playerNum].Show(dataManager.CurrentStageNum, stage.Level);
            _ranks[playerNum].Show(stage.Rank);
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
                        Damage = ScoreManager.Instance.GetBadScore(i),
                    });
                }
            }
                
            if (dataManager.IsAllPlayerGoal()) {
                TimeManager.Instance.StopGame();

                StartCoroutine(NextWaitCoroutine());

                for (int i = 0; i < GameConstants.PlayerNum; i++) {
                    var stage = dataManager.GetPlayerStage(i);
                    _letters[i].Show(dataManager.CurrentStageNum, stage.Level);
                    _ranks[i].Show(stage.Rank);
                }
            }
        }

        private IEnumerator NextWaitCoroutine() 
        {  
            yield return new WaitForSeconds (5f);  

            var dataManager = ScenesDataManager.Instance;
            dataManager.NextStage();
            LoadNextScene();
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
