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
            print("hitHole");
            charcterBehavior.StunTimer = 1.0f;
            charcterBehavior.SetAnimationTrigger("Disappear");
            charcterBehavior.Damaged(damage);
            StartCoroutine(MoveFront(charcterBehavior));
        }

        const float MoveDistance = 20.0f;
        IEnumerator MoveFront(CharcterBehavior charcterBehavior)
        {
            yield return new WaitForSeconds(1.0f);
            charcterBehavior.transform.position += charcterBehavior.transform.forward * MoveDistance;
        }
    }
}