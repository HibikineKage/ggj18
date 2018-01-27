using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj2018
{
    public class CharcterBehavior : MonoBehaviour
    {

        public float velocity;
        public float jumpForce;
        public int maxJumpFrequency;
        public float groundCheckRayDirection;

        Rigidbody rb;
        int jumpFrequency;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Walk();
            Jump();
        }

        void Walk()
        {
            var vertical = Input.GetAxisRaw("Vertical");
            var horizontal = Input.GetAxisRaw("Horizontal");
            var deltaVelocity=(transform.forward* vertical + transform.right*horizontal).normalized*velocity + new Vector3(0, rb.velocity.y, 0);

            rb.velocity = deltaVelocity;
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