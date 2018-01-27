using UnityEngine;
using UnityEditor;


namespace ggj2018
{
    public interface IDamage
    {
        void OnDamaged(CharcterBehavior charcterBehavior);
    }
}