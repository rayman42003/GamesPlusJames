using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour
{
    // Returns true if the object is killed.
    // Means that the object was destroyed and reference is null.
    public virtual bool Kill(GameObject obj)
    {
        Destroy(gameObject);
        return true;
    }
    
    // Returns true if the object respawned
    // Means that the object is being reused and reference still exists.
    public virtual bool Respawn()
    {
        return false;
    }
}
