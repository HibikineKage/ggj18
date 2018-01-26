using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj2018
{
    public class NextSceneLoader : MonoBehaviour
    {
        public void LoadNextScene()
        {
            int loadingSceneIndex = SceneUtility.GetBuildIndexByScenePath(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(loadingSceneIndex + 1);
        }
    }
}