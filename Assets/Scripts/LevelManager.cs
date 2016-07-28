using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticle;
    public GameObject spawnParticle;

    public float respawnTime= 1f;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void KillPlayer()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        StartCoroutine("DelayRespawn");       
    }

    private IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(spawnParticle, player.transform.position, player.transform.rotation);
    }
}
