using UnityEngine;
using System.Collections;

public class KillableEnemy : Killable {

    public GameObject deathParticle;

    public int killReward = 100;

    public override bool Kill(GameObject obj)
    {
        Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
        ScoreManager.AddPoints(killReward);
        Destroy(gameObject);
        return true;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
