using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{

    // Start is called before the first frame update
    public int collisionDamage = 10;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {

            Heal health = coll.gameObject.GetComponent<Heal>();
            health.TakeHit(collisionDamage);
        }
    }
}

