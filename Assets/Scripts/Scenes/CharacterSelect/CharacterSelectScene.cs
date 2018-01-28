using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj2018
{
    public class CharacterSelectScene : SceneBase<CharacterSelectScene>
    {
        public GameObject carsole;
        void Start()
        {
            for(int i=0;i < GameConstants.PlayerNum; i++)
            {
                GameObject obj=Instantiate(carsole, transform.position, Quaternion.identity);
                obj.GetComponent<Cursor>().SetData(i);
            }
        }

        void Update()
        {
            //if(InputManager.in.)
        }
    }
}