using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

   public GameObject map;
    private bool check = false;

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.M))
        {
          if(check == false)
            {
                check = true;
                map.SetActive(true);
                if( check == true)
                {
                    map.SetActive(false);
                }
            }
            
               
            
        }
    }
}
