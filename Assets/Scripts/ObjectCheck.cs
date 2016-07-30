using UnityEngine;
using System.Collections;

public class ObjectCheck : MonoBehaviour {
    public float checkRadius;
    public LayerMask mask;
    public bool ObjectFound
    {
        get; protected set;
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        ObjectFound = Physics2D.OverlapCircle(transform.position, checkRadius, mask);
    }
}
