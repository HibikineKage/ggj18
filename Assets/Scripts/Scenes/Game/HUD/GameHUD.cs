using UnityEngine;

namespace ggj2018
{
    public class GameHUD : MonoBehaviour
    {
        private Animator _animator;

        private readonly int _startAnimeHash = Animator.StringToHash("Start");

        public void Setup()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayStart()
        {
            _animator.Play(_startAnimeHash);
        }
    }
}

