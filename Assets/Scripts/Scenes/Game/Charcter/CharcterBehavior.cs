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

            float x = (playerNumber % 2 == 0 ? 0 : 0.5f);
            float y = (playerNumber / 2 == 0 ? 0 : 0.5f);
            float viewportWidth = .5f;
            float viewportHeight = .5f;

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
			bool keyCodeA = Input.GetKey(KeyCode.A);
			bool keyCodeD = Input.GetKey(KeyCode.D);
			bool keyCodeW = Input.GetKey(KeyCode.W);
			bool keyCodeS = Input.GetKey(KeyCode.S);

			var vertical = 0.0f;
			var horizontal = 0.0f;

			if (keyCodeA || keyCodeD)
			{
				if (keyCodeA)
					horizontal = -1.0f;
				if (keyCodeD)
					horizontal = 1.0f;
			}
			else
			{
				horizontal = Input.GetAxisRaw(this.horizontal);
			}

			if (keyCodeW || keyCodeS)
			{
				if (keyCodeW)
					vertical = 1.0f;
				if (keyCodeS)
					vertical = -1.0f;
			}
			else
			{
				vertical = Input.GetAxisRaw(this.vertical);
			}

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

        enum DamagePattern
        {
            collapse,
            disappear
        }
        const float collapseTime=5.0f;
        const float disappearTime=2.0f;
        void Damaged(DamagePattern damagePattern)
        {
            rb.velocity = Vector3.zero;

            switch (damagePattern)
            {
                case DamagePattern.collapse:
                    stunTimer = collapseTime;
                    childAnimator.SetTrigger("Collapse");
                    break;

                case DamagePattern.disappear:
                    stunTimer = disappearTime;
                    childAnimator.SetTrigger("Disappear");
                    break;
            }
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