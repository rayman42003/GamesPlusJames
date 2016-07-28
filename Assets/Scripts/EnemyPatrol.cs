using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    public bool movingRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask wallMask;
    private bool hittingWall;

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
	
	}

    // Update is called once per frame
    void Update() {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, wallMask);
        if (hittingWall)
            movingRight = !movingRight;

        if (movingRight)
        {
            Velocity = new Vector2(moveSpeed, Velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            Velocity = new Vector2(-moveSpeed, Velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
