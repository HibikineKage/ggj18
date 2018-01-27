using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj2018
{
    public class ManholeBehaviour : MonoBehaviour, IObstacle
    {
        public int damage;

        public void OnCollisionCharcter(CharcterBehavior charcterBehavior)
        {
            charcterBehavior.StunTimer = 0;
            charcterBehavior.SetAnimationTrigger("");
            charcterBehavior.Damaged(damage);
        }
    }
}