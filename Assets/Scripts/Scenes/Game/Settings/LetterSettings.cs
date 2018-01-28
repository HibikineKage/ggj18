using UnityEngine;

namespace ggj2018
{
    [CreateAssetMenu (menuName = "ggj2018/LetterSetting")]
    public class LetterSettings : ScriptableObject
    {
        private const int LetterMax = 6;

        [SerializeField]
        Sprite[] _loveletterSprites = new Sprite[LetterMax];

        [SerializeField]
        Sprite[] _posterSprites = new Sprite[LetterMax];

        [SerializeField]
        Sprite[] _propagandaSprites = new Sprite[LetterMax];

        [SerializeField]
        Sprite[] _grandsonSprites = new Sprite[LetterMax];

        public Sprite GetSprite(int stageNum, int level)
        {
            switch (stageNum)
            {
                case 0:
                    return _loveletterSprites[level];
                case 1:
                    return _posterSprites[level];
                case 2:
                    return _propagandaSprites[level];
                case 3:
                    return _grandsonSprites[level];
                default:
                    return null; 
            }
        }
    }
}