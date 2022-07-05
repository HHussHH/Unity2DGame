using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public TMP_Text healText;
    public int health;
    public int MaxHealth;

    private void Update()
    {
        healText.text = health.ToString();
    }
    public void TakeHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Dead");

        }
    }

    public void SetHeal(int bonusHealth)
    {
        health += bonusHealth;
        if (health > MaxHealth)
        {
            health = MaxHealth;
        }
    }

}
