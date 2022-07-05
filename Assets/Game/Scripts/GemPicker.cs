using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemPicker : MonoBehaviour
{
    public int coins = 0;
    public TMP_Text coinsText;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Gem")
        {
            coins = +1;
            GetComponent<AudioSource>().PlayOneShot(clip);
            int counts = int.Parse(coinsText.text) + coins;
            
            coinsText.text = counts.ToString();

            Destroy(coll.gameObject);
        }
    }
}
