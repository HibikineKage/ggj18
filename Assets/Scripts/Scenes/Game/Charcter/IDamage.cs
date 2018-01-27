using UnityEngine;
using UnityEditor;


namespace ggj2018
{
    public interface IDamage
    {
        /// <summary>
        /// ダメージの値
        /// </summary>
        /// <returns></returns>
        float Damage();
        /// <summary>
        /// ダメージを受けた時の処理
        /// </summary>
        /// <param name="charcterBehavior"></param>
        void OnDamaged(CharcterBehavior charcterBehavior);
    }
}