using UnityEngine;
using UnityEditor;

namespace ggj2018
{
    public class Disappear : MonoBehaviour
    {
        const float disappearTime = 2.0f;
        public float Damage()
        {
            return 5.0f;
        }
        public void OnDamaged(CharcterBehavior charcterBehavior)
        {

            charcterBehavior.StunTimer = disappearTime;
            charcterBehavior.SetAnimationTrigger("Disappear");
        }
    }
}