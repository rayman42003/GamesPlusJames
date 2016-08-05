using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
    
    public int damage = 1;

    public virtual void Attack(GameObject obj)
    {
        Attackable attackable = obj.gameObject.GetComponentInChildren<Attackable>();
        if (attackable != null)
        {
            attackable.TakeDamage(gameObject, damage);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        Attack(obj.gameObject);
    }
}
