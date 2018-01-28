using UnityEngine;

namespace ggj2018
{
    public class Collapse : MonoBehaviour 
	{
        const float collapseTime = 5.0f;
        public float Damage()
        {
            return 5.0f;
        }
        public void OnDamaged(CharcterBehavior charcterBehavior)
        {
            charcterBehavior.StunTimer = collapseTime;
            charcterBehavior.SetAnimationTrigger("Collapse");
        }
    }
}