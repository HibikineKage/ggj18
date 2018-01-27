using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj2018
{
    public class GoalBehavior : MonoBehaviour
    {

        void Start()
        {

        }

        void Update()
        {

        }

        public void Goal(int playerNum)
        {
            var dataManager = ScenesDataManager.Instance;
            dataManager.AddStageResult(playerNum, new ggj2018.ScenesDataManager.PlayerStageResult(){
                Rank = dataManager.GetCurrentRank(),
                RemainTime = TimeManager.Instance.RemainSec,
                BadScore = ScoreManager.Instance.GetBadScore(playerNum),
            });
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
    }
}
