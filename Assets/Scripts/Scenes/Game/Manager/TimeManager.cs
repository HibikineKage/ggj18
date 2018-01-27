using UnityEngine;

namespace ggj2018
{
    public class TimeManager : MonoSingleton<TimeManager>
    {
        event System.Action OnTimeup;
    }
}

