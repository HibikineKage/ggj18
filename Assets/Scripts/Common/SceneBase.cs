using System;

namespace GGJ2018A.Common
{
    public class SceneBase <T> : MonoSingleton<T>
        where T : SceneBase<T>
    {
    }
}

