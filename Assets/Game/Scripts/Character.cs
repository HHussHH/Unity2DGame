using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject panel;
   [SerializeField] GameObject obj;
   [SerializeField] GameObject cam;

    public int count;

    public void CharacterOne()
    {
        count = 1;
        ResultCharacter();
    }

    public void CharacterTwo()
    {
        count = 2;
        ResultCharacter();
    }

    public void CharacterThree()
    {
        count = 3;
        ResultCharacter();
    }

    public void ResultCharacter()
    {
        if (count == 1)
        {
            obj.SetActive(true);
            cam.SetActive(true);
        }
        if (count == 2)
        {
            obj.SetActive(true);
            cam.SetActive(true);
        }
        if (count == 3)
        {
            obj.SetActive(true);
            cam.SetActive(true);
        }

    }
}
