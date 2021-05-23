using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private MusicLibrary music;

    public float speed;
    public float jumpPower;
    public int extraJumps = 1;

    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Transform feet;

    int jumpCount = 0;
    bool isGrounded;
    float mx;
    float jumpCoolDown;

    public float dashDistance = 15f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        music = FindObjectOfType<MusicLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (!isGrounded)
        {
            // Dashing Left
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
                {
                    StartCoroutine(Dash(-1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.2f;
                }
                lastKeyCode = KeyCode.A;
            }

            // Alt Dashing Left
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.LeftArrow)
                {
                    StartCoroutine(Dash(-1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.2f;
                }
                lastKeyCode = KeyCode.LeftArrow;
            }


            // Dashing Right
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
                {
                    StartCoroutine(Dash(1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.2f;
                }
                lastKeyCode = KeyCode.D;
            }

            // Alt Dashing Right
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (doubleTapTime > Time.time && lastKeyCode == KeyCode.RightArrow)
                {
                    StartCoroutine(Dash(1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.2f;
                }
                lastKeyCode = KeyCode.RightArrow;
            }
        }

        CheckGrounded();
    }

    private void FixedUpdate()
    {
        if (!isDashing || isGrounded)
        {
            rb.velocity = new Vector2(speed * mx, rb.velocity.y);
        }
    }

    void Jump()
    {
        if(isGrounded || jumpCount < extraJumps)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
            music.JumpFX.Play();
        }
    }

    void CheckGrounded()
    {
        if(Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if(Time.time < jumpCoolDown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    IEnumerator Dash (float direction)
    {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb.gravityScale = gravity;
    }
}
