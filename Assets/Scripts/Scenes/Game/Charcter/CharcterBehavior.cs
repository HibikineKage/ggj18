using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj2018
{
    public class CharcterBehavior : MonoBehaviour
    {

        public float force;
        public float maxVelocity;
        public float jumpForce;
        public int maxJumpFrequency;
        public float groundCheckRayDirection;

        Rigidbody rb;
        Animator childAnimator;
        int jumpFrequency;
        float stunTimer;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            childAnimator = transform.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) { childAnimator.SetTrigger("Collapse"); }
            if (Input.GetKeyDown(KeyCode.Q)) { childAnimator.SetTrigger("Disappear"); }
            if (stunTimer <= 0)
            {
                Walk();
                Jump();
            }
        }

        void Walk()
        {
            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxisRaw("Horizontal");
            
            var deltaForce = (transform.forward * vertical + transform.right * horizontal).normalized * force;
            if (rb.velocity.sqrMagnitude<=maxVelocity*maxVelocity)
            {
                rb.AddForce(deltaForce);
            }
        }

        void Jump()
        {
            if (Input.GetButtonDown("Fire1") && jumpFrequency < maxJumpFrequency)
            {
                jumpFrequency++;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            var result = Physics.Raycast(transform.position, -transform.up, groundCheckRayDirection);
            Debug.DrawLine(transform.position, transform.position - transform.up * groundCheckRayDirection);
            if (result) jumpFrequency = 0;
        }

        void Damaged(float stunTime)
        {
            stunTimer = stunTime;
        }

        void OnCollisionEnter(Collision collision)
        {
            var obstacle = collision.gameObject.GetComponent<IObstacle>();
            if (obstacle != null)
            {
                obstacle.OnCollisionCharcter(this);
            }
        }
    }
}