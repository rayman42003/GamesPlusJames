using UnityEngine;
using System.Collections;

public class Killer: Attacker {

    public override void Attack(GameObject obj)
    {
        Attackable attackable = obj.gameObject.GetComponentInChildren<Attackable>();
        if (attackable != null)
        {
            attackable.Instakill(gameObject);
        }
    }
}
