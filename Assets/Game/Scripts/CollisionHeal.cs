using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{

    // Start is called before the first frame update
    public int collisionHeal = 10;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {

            Heal health = coll.gameObject.GetComponent<Heal>();
            health.SetHeal(collisionHeal);
            Destroy(gameObject);
        }
    }
}
