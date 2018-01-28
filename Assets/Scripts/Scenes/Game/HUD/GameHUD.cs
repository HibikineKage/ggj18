using UnityEngine;

namespace ggj2018
{
    public class GameHUD : MonoBehaviour
    {
        private Animator _animator;

        private readonly int _startAnimeHash = Animator.StringToHash("Start");

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayStart()
        {
            _animator.Play(_startAnimeHash);
        }
    }
}

