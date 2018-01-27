using UnityEngine;

namespace ggj2018
{
    public interface IObstacle
    {
        void OnCollisionCharcter(CharcterBehavior charcterBehavior);
    }
}