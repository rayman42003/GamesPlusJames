using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;
    public float gravityScale = 5f;

    public ObjectCheck groundCheck;

    private bool doubleJumped;

    private Animator animator;

    public Transform firingLocation;
    public GameObject projectile;

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
	
	// Update is called once per frame
	void Update () {
        if (groundCheck.ObjectFound)
            doubleJumped = false;

        if ( (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            && !doubleJumped)
        {
            Jump();
            if (!groundCheck.ObjectFound)
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
        animator.SetBool("Grounded", groundCheck.ObjectFound);

        if (Velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (Velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(projectile, firingLocation.position, firingLocation.rotation);
        }
	}

    private void Jump()
    {
        Velocity = new Vector2(Velocity.x, jumpHeight);
    }
}
