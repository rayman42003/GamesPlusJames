using UnityEngine;
using System.Collections;

public class ObjectChecker : MonoBehaviour {
    public float checkRadius;
    public LayerMask mask;
    public bool ObjectFound
    {
        get; protected set;
    }
	
	// Update is called once per frame
	void Update () {
        ObjectFound = Physics2D.OverlapCircle(transform.position, checkRadius, mask);
    }
}
