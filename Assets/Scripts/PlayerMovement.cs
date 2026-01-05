using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float jumpForce = 14f;
    public bool IsFlipped = false;
    [SerializeField] private bool active = true; // Serialize Field for debug purpose. Can be removed safely

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    bool isGrounded;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!active)
            return;
        HandleMovement();
        HandleJump();
        if (Input.GetKeyDown(KeyCode.E) && rb.simulated)
        {
            Interract();
        }
    }

    void FixedUpdate()
    {
        if (!active)
            return;
        CheckGround();
    }

    void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0)
            _animator.SetBool("IsRunning", true);
        else
            _animator.SetBool("IsRunning", false);
        Vector2 vel = rb.linearVelocity;
        vel.x = h * moveSpeed;
        rb.linearVelocity = vel;
        if (h >= 0.01f)
            _spriteRenderer.flipX = true;
        else if(h <= -0.01f)
            _spriteRenderer.flipX = false;
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (!IsFlipped)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            else
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -jumpForce);
            _animator.SetTrigger("Jump");
        }
    }

    void CheckGround()
    {
        Collider2D col = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        isGrounded = col != null;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    public void Disable()
    {
        _spriteRenderer.enabled = false;
        active = false;
    }

    public void Enable()
    {
        _spriteRenderer.enabled = true;
        active = true;
    }

    private void Interract() 
    {
        _animator.SetTrigger("Interract");
        rb.simulated = false;
        Invoke("PhisEnabler", 0.5f);
    }
    private void PhisEnabler() 
    {
        rb.simulated = true;
    }
}
