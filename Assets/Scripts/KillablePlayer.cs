using UnityEngine;
using System.Collections;

public class KillablePlayer : Killable{
    public GameObject deathParticle;
    public GameObject spawnParticle;

    private PlayerController player;

    public int deathPenalty = 50;

    public float respawnTime = 1f;

    void Start ()
    {
        player = GetComponentInParent<PlayerController>();
    }

    public override bool Kill(GameObject obj)
    {
        Instantiate(deathParticle, gameObject.transform.position, gameObject.transform.rotation);
        ScoreManager.AddPoints(-deathPenalty);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        Respawn();
        return false;
    }

    public override bool Respawn()
    {
        StartCoroutine("DelayRespawn");
        return true;
    }

    private IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        player.transform.position = LevelManager.Instance().currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(spawnParticle, player.transform.position, player.transform.rotation);
    }
}
