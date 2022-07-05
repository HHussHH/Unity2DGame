using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WoodPicker : MonoBehaviour
{
    private float coins = 0;
    public TMP_Text WoodText;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wood")
        {
            coins++;
            WoodText.text = coins.ToString();
            Destroy(coll.gameObject);
        }
    }
}
