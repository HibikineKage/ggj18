using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePathLoader : MonoBehaviour {

    public string loadSceneName;

	public void LoadScene()
    {
        SceneManager.LoadScene(loadSceneName);
    }
}
