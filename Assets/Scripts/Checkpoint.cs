using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            levelManager.currentCheckpoint = this.gameObject;
        }
    }
}
