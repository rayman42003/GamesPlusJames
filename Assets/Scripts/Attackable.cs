using UnityEngine;
using System.Collections;

public class Attackable : MonoBehaviour
{
    public int maxHealth = 3;
    public int currHealth;
    public Killable killable;

    public void TakeDamage(GameObject attacker, int damage)
    {
        currHealth = System.Math.Max(0, currHealth - damage);
        if (currHealth <= 0)
            KilledBy(attacker);
    }

    public void Instakill(GameObject attacker)
    {
        currHealth = 0;
        KilledBy(attacker);
    }

    private void KilledBy(GameObject attacker)
    {
        if (killable != null)
            killable.Kill(attacker);
        Reset();
    }

    public void Reset()
    {
        currHealth = maxHealth;
    }
}

