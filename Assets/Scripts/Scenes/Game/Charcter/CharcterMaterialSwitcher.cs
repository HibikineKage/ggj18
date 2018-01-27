using UnityEngine;

namespace ggj2018
{
    public class CharcterMaterialSwitcher : MonoBehaviour
    {
        [SerializeField]
        private Material[] _materials;

        public void Setup(int playerNum)
        {
            var red = GetComponentInChildren<Renderer>();
            red.material = _materials[playerNum];
        }
    }
}

