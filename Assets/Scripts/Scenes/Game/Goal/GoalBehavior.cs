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
                Damage = ScoreManager.Instance.GetBadScore(playerNum),
            });
                
            GameScene.Instance.OnGoal(playerNum);

            if (dataManager.IsAllPlayerGoal()) {
                StartCoroutine(NextWaitCoroutine());
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

        void OnTriggerEnter(Collider collider)
        {
            var charBehavior = collider.gameObject.GetComponent<CharcterBehavior>();
            if (charBehavior != null) 
            {
                Goal(charBehavior.PlayerNumber);
            }
        }
    }
}
