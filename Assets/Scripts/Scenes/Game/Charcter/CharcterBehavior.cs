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

        string vertical = "Pad0Vertical";
        string horizontal = "Pad0Horizontal";
        string jump = "Pad0Jump";

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            childAnimator = transform.GetComponentInChildren<Animator>();
        }

        public void Setup(int playerNumber)
        {
            var camera = GetComponentInChildren<Camera>();

            int x = Screen.width / 2 * (playerNumber % 2 == 0 ? 0 : 1);
            int y = Screen.height / 2 * (playerNumber / 2 == 0 ? 0 : 1);
            int viewportWidth = Screen.width / 2;
            int viewportHeight = Screen.height / 2;

            Debug.Log(x);
            Debug.Log(y);
            Debug.Log(viewportWidth);
            Debug.Log(viewportHeight);

            camera.rect = new Rect(x, y, viewportWidth, viewportHeight);

            vertical = "Pad" + playerNumber + "Vertical";
            horizontal = "Pad" + playerNumber + "Horizontal";
            jump = "Pad" + playerNumber + "Jump";
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T)) { childAnimator.SetTrigger("Collapse"); }
            if (Input.GetKeyDown(KeyCode.Q)) { childAnimator.SetTrigger("Disappear"); }
            if (stunTimer <= 0)
            {
                Walk();
                Jump();
            }
        }

        void Walk()
        {
            var vertical = Input.GetAxisRaw(this.vertical);
            var horizontal = Input.GetAxisRaw(this.horizontal);
            
            var deltaForce = (transform.forward * vertical + transform.right * horizontal).normalized * force;
            if (rb.velocity.sqrMagnitude<=maxVelocity*maxVelocity)
            {
                rb.AddForce(deltaForce);
            }
        }

        void Jump()
        {
            if (Input.GetButtonDown(jump) && jumpFrequency < maxJumpFrequency)
            {
                jumpFrequency++;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            var result = Physics.Raycast(transform.position, -transform.up, groundCheckRayDirection);
            Debug.DrawLine(transform.position, transform.position - transform.up * groundCheckRayDirection);
            if (result) jumpFrequency = 0;
        }

        void Damaged(string animationName)
        {
            //childAnimator.
            //stunTimer = stunTime;
            rb.velocity = Vector3.zero;
            childAnimator.SetTrigger("Collapse");
            childAnimator.SetTrigger("Disappear");
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