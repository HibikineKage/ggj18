using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj2018
{

    public class CharacterSelectScene : SceneBase<CharacterSelectScene>
    {
        Cursor[] _cursors;
        public GameObject carsole;
        void Start()
        {
            _cursors = new Cursor[GameConstants.PlayerNum];

            for (int i=0;i < GameConstants.PlayerNum; i++)
            {
                GameObject obj=Instantiate(carsole, transform.position, Quaternion.identity);
                obj.GetComponent<Cursor>().SetData(i);
            }
        }

        void Update()
        {
            foreach(var cur in _cursors)
            {
                if (!cur.IsTypeSelected) { return; }
            }
            int loadingSceneIndex = SceneUtility.GetBuildIndexByScenePath(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(loadingSceneIndex + 1);
        }
    }
}