using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj2018
{

    public class CharacterSelectScene : SceneBase<CharacterSelectScene>
    {
        public Fadepanel fadePanel;

        Cursor[] _cursors;
        public GameObject carsole;
        void Start()
        {
            _cursors = new Cursor[GameConstants.PlayerNum];
            ScenesDataManager.Instance.InitPlayers();

            for (int i=0;i < GameConstants.PlayerNum; i++)
            {
                GameObject obj=Instantiate(carsole, transform.position, Quaternion.identity);
                _cursors[i] = obj.GetComponent<Cursor>();
                obj.GetComponent<Cursor>().SetData(i);
            }
        }

        void Update()
        {
            foreach(var cur in _cursors)
            {
                if (!cur.IsTypeSelected) { return; }
            }
            if (!fadePanel) return;

            System.Action action = () =>
            {
                int loadingSceneIndex = SceneUtility.GetBuildIndexByScenePath(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(loadingSceneIndex + 1);
            };
            fadePanel.FadeOut(2.0f, action);
            
        }
    }
}