using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2018A.Scenes.Game
{
    public class CarBehaviour : MonoBehaviour, IObstacle
    {
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        #region override IObstacle

        void IObstacle.OnCollisionCharcter(CharcterBehavior charcterBehavior)
        {
        }

        #endregion
    }
}