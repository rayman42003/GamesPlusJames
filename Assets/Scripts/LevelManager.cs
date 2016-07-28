using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticle;
    public GameObject spawnParticle;

    public int deathPenalty;

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
        ScoreManager.AddPoints(-deathPenalty);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        StartCoroutine("DelayRespawn");       
    }

    private IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(spawnParticle, player.transform.position, player.transform.rotation);
    }
}
