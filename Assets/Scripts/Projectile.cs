using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float moveSpeed = 8f;
    public float duration = 1f;

    public GameObject impactEffect;

    public float rotationSpeed = -720f;
    private Vector2 Velocity
    {
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
    void Start() {
        StartCoroutine(DelayDeath());
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
    }

    // Update is called once per frame
    void Update() {
        Velocity = new Vector2(moveSpeed, Velocity.y);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        Quaternion rotation = transform.rotation *
            (Velocity.x > 0 ? Quaternion.Euler(0, -90, 0) : Quaternion.Euler(0, 90, 0));
        Instantiate(impactEffect, transform.position, rotation);
        Destroy(gameObject);
    }

    private IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
