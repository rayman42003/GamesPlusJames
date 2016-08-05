using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            LevelManager.Instance().currentCheckpoint = this.gameObject;
        }
    }
}
