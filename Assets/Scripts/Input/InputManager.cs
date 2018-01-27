using UnityEngine;

namespace ggj2018
{
    public class InputManager : MonoSingleton<InputManager>
    {
        public enum PadEvent
        {
            Up,
            Down,
            Left,
            Right,
            Cancel,
            Enter,
        }

        public delegate void OnPadEventHandler(int playerNum, PadEvent inputEvent);

        event OnPadEventHandler OnPadEvent;
    }
}