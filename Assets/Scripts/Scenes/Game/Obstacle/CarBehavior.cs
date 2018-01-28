using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj2018
{
    public class CarBehavior : MonoBehaviour, IObstacle
    {
        public float forwardForce;
        public float forwardHitCheckDistance;
        public float maxVelocity;
        public int damage;

        float unavailableCount = 0;
        Rigidbody rb;
        Collider col;
        public void OnCollisionCharcter(CharcterBehavior charcterBehavior)
        {
            charcterBehavior.StunTimer = 4;
            charcterBehavior.SetAnimationTrigger("Collapse");
            charcterBehavior.Damaged(damage);
            col.enabled = false;
            unavailableCount = 4;
        }

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            col = GetComponent<Collider>();
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

            if (unavailableCount > 0)
            {
                unavailableCount -= Time.deltaTime;
                if (unavailableCount <= 0)
                {
                    col.enabled = true;
                }
            }
        }

        void Broken()
        {
            Destroy(gameObject);
        }
    }
}
