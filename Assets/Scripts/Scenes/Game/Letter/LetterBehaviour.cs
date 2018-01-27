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

        public void Setup(LetterType letterType, int letterLevel)
        {
            var image = GetComponent<Image>();
            switch (letterType)
            {
                case LetterType.Loveletter:
                    image.sprite = _loveletterSprites[letterLevel];
                    break;
                case LetterType.Poster:
                    image.sprite = _posterSprites[letterLevel];
                    break;
                case LetterType.Propaganda:
                    image.sprite = _propagandaSprites[letterLevel];
                    break;
                case LetterType.Grandson:
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

