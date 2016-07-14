using UnityEngine;
using System.Collections;

public class DestroyParticles : MonoBehaviour {
    private ParticleSystem particles;
	// Use this for initialization
	void Start () {
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (particles && !particles.IsAlive())
            Destroy(gameObject);
	}
}
