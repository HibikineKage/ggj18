using System;

namespace ggj2018
{
    public class SceneBase <T> : MonoSingleton<T>
        where T : SceneBase<T>
    {
    }
}

