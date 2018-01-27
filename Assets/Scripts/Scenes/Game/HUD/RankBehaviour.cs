using UnityEngine;
using UnityEngine.UI;

namespace ggj2018
{
    public class RankBehaviour : MonoBehaviour
    {
        public void Show(int rank)
        {
            var text = GetComponent<Text>();
            text.text = (rank + 1) + "位";

            if (!gameObject.activeSelf) {
                gameObject.SetActive(true);
            }
        }
    }
}

