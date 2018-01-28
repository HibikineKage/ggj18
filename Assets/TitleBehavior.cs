using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ggj2018 { 
    public class TitleBehavior : MonoBehaviour {

        NextSceneLoader nsl;

        private void Start()
        {
            nsl = GetComponent<NextSceneLoader>();
        }

        // Update is called once per frame
        void Update () {
		    if (Input.GetKey(KeyCode.A) || Input.GetButtonUp("Pad0Jump"))
            {
                nsl.LoadNextScene();
            }
	    }
    }
}
