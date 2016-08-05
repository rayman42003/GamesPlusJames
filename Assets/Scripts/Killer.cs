using UnityEngine;
using System.Collections;

public class Killer: MonoBehaviour {

    void OnTriggerEnter2D(Collider2D obj)
    {
        Killable killable = obj.gameObject.GetComponentInChildren<Killable>();
        if (killable != null)
        {
            killable.Kill(obj.gameObject);
        }
    }
}
