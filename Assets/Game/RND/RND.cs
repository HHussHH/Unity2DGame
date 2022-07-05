using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RND : MonoBehaviour
{
    public GameObject[] obj;
    void Start()
    {
        int rnd = Random.Range(0, obj.Length);
        Instantiate(obj[rnd], transform.position, Quaternion.identity);
    }
}
