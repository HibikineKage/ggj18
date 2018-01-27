using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj2018
{
    public class CarBehavior : MonoBehaviour, IObstacle
    {
        [SerializeField]
        float forwardForce;
        [SerializeField]
        float forwardHitCheckDistance;
        [SerializeField]
        float maxVelocity;

        Rigidbody rb;
        public void OnCollisionCharcter(CharcterBehavior charcterBehavior)
        {
            //charcterBehavior.Damaged();
        }

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
			SeManager.Instance.PlayCar ();
            if (rb.velocity.sqrMagnitude <= maxVelocity * maxVelocity)
            {
                rb.AddForce(forwardForce * transform.forward * Time.deltaTime);
            }

            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward,out hit, forwardHitCheckDistance);
            Debug.DrawRay(transform.position, transform.forward*forwardHitCheckDistance);
            if (hit.collider&&hit.collider.tag != "Player") Broken();//キャラクター意外にヒットしたら破壊
        }

        void Broken()
        {
            Destroy(gameObject);
        }
    }
}
