using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATP1_CW2
{
    public class Player : MonoBehaviour
    {
        Animator animator;
        Rigidbody2D rigidBody;
        SpriteRenderer spriteRenderer;

        private PlayerState playerState;

        [SerializeField]private float moveSpeed=4f;
        [SerializeField]private float jumpHeight = 30f;


        [Header("Jump Settings")]
        [Range(0,10)]public float distance;
        [SerializeField]private LayerMask layerMask;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
            playerState = PlayerState.idle;
        }

        void Update()
        {
            RaycastHit2D hit;

            hit = Physics2D.Raycast(transform.position, Vector2.down, distance, layerMask);

            Vector3 down = transform.TransformDirection(Vector3.down) * distance;
            Debug.DrawRay(transform.position, down, Color.green);

            if (hit.collider!=null)
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            Movement();
        }

        public void Movement()
        {
            float x = Input.GetAxis("Horizontal"); //Debug.Log("X:" + x);

            if(x<-0.1)
            {
                spriteRenderer.flipX = true;
            }
            else if(x>0.1)
            {
                spriteRenderer.flipX = false;
            }

            rigidBody.velocity = new Vector2(x* moveSpeed, rigidBody.velocity.y);

            animator.SetFloat("move", Mathf.Abs(x));
        }

        public void Jump()
        {
            float jump = Input.GetAxis("Jump");
            rigidBody.AddForce(Vector2.up * jump * jumpHeight * Time.deltaTime, ForceMode2D.Impulse);

            Debug.Log("Y:" + Mathf.Abs(rigidBody.velocity.y));
            //animator.SetFloat("Jump", rigidBody.velocity.y);
            animator.SetBool("CanJump", false );
        }

        public void Dash()
        {
            Vector2 dashDir = new Vector2(transform.position.x, 0);
            rigidBody.MovePosition(dashDir*3*Time.deltaTime);
        }
    }

    public enum PlayerState
    {
        idle,
        walk,
        run,
        jump,
    }
}