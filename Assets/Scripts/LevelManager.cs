using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticle;
    public GameObject spawnParticle;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player respawned");
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.transform.position = currentCheckpoint.transform.position;
        Instantiate(spawnParticle, player.transform.position, player.transform.rotation);
    }
}
