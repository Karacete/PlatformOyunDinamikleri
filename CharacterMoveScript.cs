using UnityEngine;

public class CharacterMoveScript : MonoBehaviour
{
    [SerializeField]
    private int walkSpeed;
    [SerializeField]
    private int jumpSpeed;
    private float horizontalMove;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;
        isJump = false;
    }
    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * Time.deltaTime * walkSpeed, rb.velocity.y);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            sr.flipX = false;
        if (Input.GetKey(KeyCode.A))
            sr.flipY = true;
        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            isJump = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isJump = false;
    }
}
