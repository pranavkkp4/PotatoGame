using UnityEngine;

namespace PotatoGame.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 8f;
        [SerializeField] private float jumpForce = 16f;
        [SerializeField] private float coyoteTime = 0.15f;
        [SerializeField] private float jumpBuffer = 0.1f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform feetPoint;
        [SerializeField] private Vector2 feetBoxSize = new Vector2(0.6f, 0.1f);

        [Header("Wall Slide")]
        [SerializeField] private bool enableWallSlide = true;
        [SerializeField] private float wallSlideSpeed = 2f;
        [SerializeField] private Vector2 wallCheckOffset = new Vector2(0.5f, 0f);

        private Rigidbody2D body;
        private float coyoteCounter;
        private float jumpBufferCounter;
        private int facing = 1;
        private bool isWallSliding;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            HandleMovement(inputX);
            HandleFacing(inputX);
            HandleJump(inputX);
        }

        private void HandleMovement(float inputX)
        {
            Vector2 velocity = body.velocity;
            velocity.x = inputX * moveSpeed;

            if (enableWallSlide && isWallSliding)
            {
                velocity.y = Mathf.Clamp(velocity.y, -wallSlideSpeed, float.MaxValue);
            }

            body.velocity = velocity;
        }

        private void HandleFacing(float inputX)
        {
            if (Mathf.Abs(inputX) > 0.01f)
            {
                facing = inputX > 0 ? 1 : -1;
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x) * facing;
                transform.localScale = scale;
            }
        }

        private void HandleJump(float inputX)
        {
            bool grounded = IsGrounded();
            UpdateCoyoteTime(grounded);
            UpdateJumpBuffer();
            HandleWallSlide(inputX);

            if (jumpBufferCounter > 0f && coyoteCounter > 0f)
            {
                PerformJump();
            }

            if (Input.GetButtonUp("Jump") && body.velocity.y > 0f)
            {
                body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
            }
        }

        private void UpdateCoyoteTime(bool grounded)
        {
            if (grounded)
            {
                coyoteCounter = coyoteTime;
            }
            else
            {
                coyoteCounter -= Time.deltaTime;
            }
        }

        private void UpdateJumpBuffer()
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpBufferCounter = jumpBuffer;
            }
            else
            {
                jumpBufferCounter -= Time.deltaTime;
            }
        }

        private void PerformJump()
        {
            jumpBufferCounter = 0f;
            coyoteCounter = 0f;
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapBox(feetPoint.position, feetBoxSize, 0f, groundLayer);
        }

        private void HandleWallSlide(float inputX)
        {
            if (!enableWallSlide)
            {
                isWallSliding = false;
                return;
            }

            bool touchingWall = Physics2D.Raycast(transform.position, Vector2.right * facing, wallCheckOffset.x, groundLayer);
            bool grounded = IsGrounded();
            isWallSliding = touchingWall && !grounded && Mathf.Abs(inputX) > 0.1f;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (feetPoint == null)
            {
                return;
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(feetPoint.position, feetBoxSize);
            Gizmos.color = Color.cyan;
            Vector3 origin = transform.position;
            Gizmos.DrawLine(origin, origin + Vector3.right * facing * wallCheckOffset.x);
        }
#endif
    }
}
