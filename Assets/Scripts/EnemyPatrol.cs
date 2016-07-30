using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    public bool movingRight;

    public ObjectCheck wallCheck;

    public ObjectCheck edgeCheck;

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
        if (wallCheck.ObjectFound || !edgeCheck.ObjectFound)
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
