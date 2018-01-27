using UnityEngine;
using System.Collections.Generic;

namespace ggj2018
{
    public class GameScene : SceneBase<GameScene>
    {
        CharcterBehavior[] characters;
        private void Start()
        {
            characters = GetComponentsInChildren<CharcterBehavior>();
            for(var i = 0; i < characters.Length; i += 1)
            {
                characters[i].Setup(i);
            }
        }
    }
}