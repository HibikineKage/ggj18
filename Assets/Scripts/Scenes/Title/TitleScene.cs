using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj2018
{
    public class TitleScene : MonoSingleton<TitleScene>
    {
        void Update()
        {
            if (Input.GetButtonDown("Pad0Jump") || Input.GetKey(KeyCode.Space))
            {
                var dataManager = ScenesDataManager.Instance;
                dataManager.InitStage();
                dataManager.InitPlayers();
                LoadNextScene();
            }
        }

        public void LoadNextScene()
        {
            int loadingSceneIndex = SceneUtility.GetBuildIndexByScenePath(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(loadingSceneIndex + 1);
        }
    }
}