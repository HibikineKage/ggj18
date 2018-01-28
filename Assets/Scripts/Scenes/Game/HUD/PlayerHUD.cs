using UnityEngine;
using UnityEngine.UI;

namespace ggj2018
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField]
        private Text _numText;

        [SerializeField]
        private Image _letterImage;

        [SerializeField]
        private Text _rankText;

        [SerializeField]
        private Text _commentText;

        [SerializeField]
        private LetterSettings _letterSettings;

        public void Setup(int playerNum)
        {
            _numText.text = (playerNum + 1) + "P";
        }

        public void ShowResult(int rank, int stage,  int level)
        {
            _letterImage.gameObject.SetActive(true);
            _letterImage.sprite = _letterSettings.GetSprite(stage, level);

            _rankText.gameObject.SetActive(true);
            _rankText.text = rank + "位";

            _commentText.gameObject.SetActive(true);
            switch (level)
            {
                case 5:
                    _commentText.text = "大変良くできました";
                    break;
                case 4:
                    _commentText.text = "良くできました";
                    break;
                case 3:
                    _commentText.text = "普通です";
                    break;
                case 2:
                    _commentText.text = "ちょっと駄目です";
                    break;
                case 1:
                    _commentText.text = "駄目です";
                    break;
                case 0:
                    _commentText.text = "すごく駄目です";
                    break;
            }
        }
    }
}

