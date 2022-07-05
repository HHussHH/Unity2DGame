using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StonePicker : MonoBehaviour
{
    private float coins = 0;
    public TMP_Text stoneText;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Stone")
        {
            coins++;
            stoneText.text = coins.ToString();
            Destroy(coll.gameObject);
        }
    }
}
