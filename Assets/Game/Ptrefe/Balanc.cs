using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Balanc : MonoBehaviour
{
    public TMP_Text MagB;
    public TMP_Text WarB;
    public TMP_Text DevilB;
    public TMP_Text final;

    int gem = 0;



    private void Update()
    {
        gem = int.Parse(MagB.text) + int.Parse(WarB.text) + int.Parse(DevilB.text);
        final.text = gem.ToString();
    }
}
