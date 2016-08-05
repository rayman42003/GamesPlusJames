using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
    
    public int Value;

    void OnTriggerEnter2D (Collider2D obj)
    {
        if(obj.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ScoreManager.AddPoints(Value);
            Destroy(gameObject);
        }
    }
}
