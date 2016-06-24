using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundMask;
    private bool grounded;

    private bool doubleJumped;

    private Vector2 RigidBody {
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
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RigidBody = new Vector2(moveSpeed, RigidBody.y);
        }
	    if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RigidBody = new Vector2(-moveSpeed, RigidBody.y);
        }
	}

    private void Jump()
    {
        RigidBody = new Vector2(RigidBody.x, jumpHeight);
    }
}
