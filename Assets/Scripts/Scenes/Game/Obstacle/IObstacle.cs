using UnityEngine;

namespace GGJ2018A.Scenes.Game
{
    public interface IObstacle
    {
        void OnCollisionCharcter(CharcterBehavior charcterBehavior);
    }
}