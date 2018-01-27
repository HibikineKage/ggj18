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

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Goal();
            }
        }

        void Goal()
        {
            LoadNextScene();
        }

        void LoadNextScene()
        {
            int loadingSceneIndex = SceneUtility.GetBuildIndexByScenePath(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(loadingSceneIndex + 1);
        }
    }
}
