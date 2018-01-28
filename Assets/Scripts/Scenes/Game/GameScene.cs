using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

namespace ggj2018
{
    public class GameScene : SceneBase<GameScene>
    {

        public GameObject _hitParticle;
        private CharcterBehavior[] _charcters;

        private GameHUD _gameHUD;
        private PlayerHUD[] _playerHUD;

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
            _playerHUD = GetComponentsInChildren<PlayerHUD>();
            for (var i = 0; i < GameConstants.PlayerNum; i++) 
            {
                _charcters[i].Setup(i);
                _charcters[i].SetHitParticle(_hitParticle);
                _playerHUD[i].Setup(i);
            }
            _gameHUD = GetComponentInChildren<GameHUD>();
            _gameHUD.Setup();
            _gameHUD.PlayStart();

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
                if(_remainTime!=null)_remainTime.text  = min + ":" + string.Format("{0:00}", sec);
            }
        }

        public void OnGoal(int playerNum)
        {  
            var dataManager = ScenesDataManager.Instance;
            if (dataManager.IsPlayerGoal(playerNum)) {
                return;
            }

            var stage = new ScenesDataManager.PlayerStageResult(){
                Rank = dataManager.GetCurrentRank(),
                RemainTime = TimeManager.Instance.RemainSec,
                Damage = ScoreManager.Instance.GetBadScore(playerNum),
            };
            dataManager.AddStageResult(playerNum, stage);
            _playerHUD[playerNum].ShowResult(stage.Rank, dataManager.CurrentStageNum, stage.Level);

            if (dataManager.IsAllPlayerGoal()) {
                TimeManager.Instance.StopGame();
                StartCoroutine(NextWaitCoroutine());
            }
        }

        void OnTimeup()
        {   
            var dataManager = ScenesDataManager.Instance;
            for (int i = 0; i < GameConstants.PlayerNum; i++) {
                if (!dataManager.IsPlayerGoal(i)) {
                    var stage = new ScenesDataManager.PlayerStageResult(){
                        Rank = 4,
                        RemainTime = 0,
                        Damage = ScoreManager.Instance.GetBadScore(i),
                    };
                    dataManager.AddStageResult(i, stage);
                    _playerHUD[i].ShowResult(stage.Rank, dataManager.CurrentStageNum, stage.Level);
                }
            }
                
            TimeManager.Instance.StopGame();
            StartCoroutine(NextWaitCoroutine());
        }

        private IEnumerator NextWaitCoroutine() 
        {  
            yield return new WaitForSeconds (10f);  

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
				BgmManager.Instance.PlayMainBGM ();
			} else if (scene.name == "Stage3") {
				BgmManager.Instance.PlayStage3Background ();
				BgmManager.Instance.PlayMainBGM ();
			} else if (scene.name == "Stage4") {
				BgmManager.Instance.PlayStage4Background ();
				BgmManager.Instance.PlayMainBGM ();
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
