using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj2018
{
	public partial class CharcterBehavior : MonoBehaviour, IObstacle
    {

        public float force;
        public float maxVelocity;
        public float jumpForce;
        public int maxJumpFrequency;
        public float groundCheckRayDirection;
		public string name;


        Rigidbody rb;
        Animator childAnimator;
        int jumpFrequency;
        int playerNumber;
        public int PlayerNumber
        {
            get { return playerNumber; }
        }
        GameObject hitParticle;

        /// <summary>
        /// ダメージを受けている間のカウンター
        /// 毎フレーム減り続け、ゼロになると起き上がる
        /// </summary>
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
            this.playerNumber = playerNumber;

            var camera = GetComponentInChildren<Camera>();

            print(PlayerNumber);

            float x = playerNumber % 2 == 0 ? 0 : 0.5f;
            float y = playerNumber / 2 == 0 ? 0.5f : 0;
            float viewportWidth = .5f;
            float viewportHeight = .5f;

            camera.rect = new Rect(x, y, viewportWidth, viewportHeight);

            vertical = "Pad" + playerNumber + "Vertical";
            horizontal = "Pad" + playerNumber + "Horizontal";
            jump = "Pad" + playerNumber + "Jump";

            //var _materialSwitcher = GetComponent<CharcterMaterialSwitcher>();
            //_materialSwitcher.Setup(playerNumber);
        }

        void Update()
        {
            // デバッグ用
            if (Input.GetKeyDown(KeyCode.T)) { childAnimator.SetTrigger("Collapse"); }
            if (Input.GetKeyDown(KeyCode.Q)) { childAnimator.SetTrigger("Disappear"); }


            if (stunTimer <= 0)
            {
                Walk();
                Jump();
            }else
            {
                stunTimer -= Time.deltaTime;
            }
        }

        void Walk()
        {
            float horizontal = GetWalkHorizontal();
            float vertical = GetWalkVertical();

			var deltaForce = (transform.forward * vertical + transform.right * horizontal).normalized * force;
            if (rb.velocity.sqrMagnitude<=maxVelocity*maxVelocity)
            {
                rb.AddForce(deltaForce);
            }
        }

        void Jump()
        {
            if (GetJumpInput() && jumpFrequency < maxJumpFrequency)
            {
                jumpFrequency++;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				Sound ();
            }

            var result = Physics.Raycast(transform.position, -transform.up, groundCheckRayDirection);
            Debug.DrawLine(transform.position, transform.position - transform.up * groundCheckRayDirection);
            if (result) jumpFrequency = 0;
        }

        public void SetAnimationTrigger(string animationName)
        {
            this.childAnimator.SetTrigger(animationName);
        }

        public float StunTimer
        {
            get
            {
                return this.stunTimer;
            }
            set
            {
                if (this.stunTimer <= 0)
                {
                    this.stunTimer = value;
                }
            }
        }
        public void Damaged(int damage)
        {
            rb.velocity = Vector3.zero;

            ScoreManager.Instance.AddBadScore(playerNumber, damage);
        }

        void OnCollisionEnter(Collision collision)
        {
            var obstacle = collision.gameObject.GetComponent<IObstacle>();
            if (obstacle != null)
            {
                obstacle.OnCollisionCharcter(this);
            }
        }


        const float reboundForce = 1000.0f;
        public void OnCollisionCharcter(CharcterBehavior charcterBehavior)
        {
            Vector3 direction = this.transform.position - charcterBehavior.transform.position;
            this.rb.AddForce(direction.normalized * reboundForce);
			AngrySound ();
            generateHitParticle();
        }


        void generateHitParticle()
        {
            if (hitParticle != null)
            {
                Instantiate(hitParticle, this.transform.position, this.transform.rotation);
            }
        }

        bool GetJumpInput()
        {
            return Input.GetButtonDown(jump);
        }

        float GetWalkVertical()
        {
            bool keyCodeW = Input.GetKey(KeyCode.W);
            bool keyCodeS = Input.GetKey(KeyCode.S);

            var vertical = 0.0f;

            if (keyCodeW || keyCodeS)
            {
                if (keyCodeS)
                    vertical = -1.0f;
                if (keyCodeW)
                    vertical = 1.0f;
            }
            else
            {
                vertical = -Input.GetAxisRaw(this.vertical);
            }

            return vertical;
        }

        float GetWalkHorizontal()
        {
            bool keyCodeA = Input.GetKey(KeyCode.A);
            bool keyCodeD = Input.GetKey(KeyCode.D);

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

            return horizontal;
        }


		void Sound ()
		{
			if (this.name == "Goat") 
			{
				SeManager.Instance.PlayGoat ();
			} else if (this.name == "Penguin") 
			{
				SeManager.Instance.PlayPenguin ();
			} else if (this.name == "Dove") 
			{
				SeManager.Instance.PlayPigeon ();
			} else 
			{
				SeManager.Instance.PlayCat ();
			}
		}

		void AngrySound()
		{
			if (this.name == "Goat") 
			{
				SeManager.Instance.PlayAngryGoat ();
			} else if (this.name == "Penguin") 
			{
				SeManager.Instance.PlayAngryPenguin ();
			} else if (this.name == "Dove") 
			{
				SeManager.Instance.PlayAngryPigeon ();
			} else 
			{
				SeManager.Instance.PlayAngryCat ();
			}
		}

        public void SetHitParticle(GameObject particle)
        {
            this.hitParticle = particle;
        }
    }
}
