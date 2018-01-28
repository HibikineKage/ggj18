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
            GameScene.Instance.OnGoal(playerNum);
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
