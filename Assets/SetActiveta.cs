using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveta : MonoBehaviour
{
    public Image CAM1;
    public Image CAM2;
    public Image CAM3;
    //public Image CAM3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            CAM1.gameObject.SetActive(true);
            CAM2.gameObject.SetActive(true);
            CAM3.gameObject.SetActive(true);
        } 
     }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CAM1.gameObject.SetActive(false);
            CAM2.gameObject.SetActive(false);
            CAM3.gameObject.SetActive(false);
        }
    }
}
   

    



