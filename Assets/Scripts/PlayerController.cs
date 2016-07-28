using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;
    public float gravityScale = 5f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundMask;
    private bool grounded;

    private bool doubleJumped;

    private Animator animator;

    private Vector2 Velocity {
        get
        {
            return GetComponent<Rigidbody2D>().velocity;
        }
        set
        {
            GetComponent<Rigidbody2D>().velocity = value;
        }
    }

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().gravityScale = gravityScale;
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
        if (grounded)
            doubleJumped = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if( (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            && !doubleJumped)
        {
            Jump();
            if (!grounded)
                doubleJumped = true;
        }

        moveVelocity = 0f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = moveSpeed;
        }
	    if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -moveSpeed;
        }

        Velocity = new Vector2(moveVelocity, Velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(Velocity.x));
        animator.SetBool("Grounded", grounded);

        if (Velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (Velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
	}

    private void Jump()
    {
        Velocity = new Vector2(Velocity.x, jumpHeight);
    }
}
