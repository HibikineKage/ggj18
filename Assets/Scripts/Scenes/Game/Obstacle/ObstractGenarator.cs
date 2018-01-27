using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj2018
{

    public class ObstractGenarator : MonoBehaviour
    {
        public GameObject Obstacle;
        public float GenerateRate;
        public float RandomRange;
        public bool RealtimeGenerate = true;
        void Start()
        {
            if (!RealtimeGenerate)
            {
                for (var i = 0; i < GenerateRate; i += 1)
                {
                    Generate();
                }
            }
        }

        void Update()
        {
            if (RealtimeGenerate)
            {
                if (Random.Range(0, 1000) < GenerateRate)
                {
                    Generate();
                }
            }
        }

        void Generate()
        {
            var io = Instantiate(Obstacle, this.transform.position + new Vector3(
              Random.Range(-RandomRange, RandomRange),
              0,
              Random.Range(-RandomRange, RandomRange)), this.transform.rotation);
        }
    }
}