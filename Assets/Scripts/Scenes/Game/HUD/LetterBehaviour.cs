using UnityEngine;
using UnityEngine.UI;

namespace ggj2018
{
    public class LetterBehaviour : MonoBehaviour
    {
        public enum LetterType
        {
            Loveletter,
            Poster,
            Propaganda,
            Grandson,
        }

        [SerializeField]
        Sprite[] _loveletterSprites;

        [SerializeField]
        Sprite[] _posterSprites;

        [SerializeField]
        Sprite[] _propagandaSprites;

        [SerializeField]
        Sprite[] _grandsonSprites;

        public void Show(int stageNum, int letterLevel)
        {
            var image = GetComponent<Image>();
            switch (stageNum)
            {
                case 0:
                    image.sprite = _loveletterSprites[letterLevel];
                    break;
                case 1:
                    image.sprite = _posterSprites[letterLevel];
                    break;
                case 2:
                    image.sprite = _propagandaSprites[letterLevel];
                    break;
                case 3:
                    image.sprite = _grandsonSprites[letterLevel];
                    break;
                default:
                    break;
            }

            if (!gameObject.activeSelf) {
                gameObject.SetActive(true);
            }
        }
    }
}

