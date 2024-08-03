using UnityEngine;

public class PhysicMovemant : MonoBehaviour
{
    public Animator _animator;
    public LayerMask _groundMask;
    public Vector2 moveVector;
    public float _groundRadius = 0.2f;
    public int _speed = 3;
    public int jumpForce = 400;
    public bool _onGround;
    public Transform _grounCheck;
    private SpriteRenderer sprite;
    private Rigidbody2D rb2d;
    private int facingDirection = 1;
    private int _jumpCount = 0;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Walk();
        Reflect();
        Jump();
        CheckingGround();
    }

    public void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveVector.x * _speed, rb2d.velocity.y);
        _animator.SetFloat("Move", Mathf.Abs(moveVector.x));
    }

    private void Reflect()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
            facingDirection = 1;
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = true;
            facingDirection = -1;
        }
    }

    private void CheckingGround()
    {
        _onGround = Physics2D.OverlapCircle(_grounCheck.position, _groundRadius, _groundMask);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
            {
                rb2d.AddForce(Vector2.up * jumpForce);
            }
            if (_onGround)
            {
                _jumpCount = 0;
            }
    }
}