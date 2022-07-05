using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResolution : MonoBehaviour
{
    public Dropdown dropdown;

    public void Change()
    {
        if(dropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        if (dropdown.value == 1)
        {
            Screen.SetResolution(1200, 1000, true);
        }
        if (dropdown.value == 2)
        {
            Screen.SetResolution(1250, 800, true);
        }
        if (dropdown.value == 3)
        {
            Screen.SetResolution(3840, 2160, true);
        }
        
    }
}
