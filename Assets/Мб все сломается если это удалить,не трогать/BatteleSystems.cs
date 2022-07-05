using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattelStates { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BatteleSystems : MonoBehaviour
{

    public GameObject playerPref;
    public GameObject enemPref;

    public Transform playerBattelStation;
    public Transform enemyBattelStation;

    public Text dialogText;

    public BattleHUDs playerHUD;
    public BattleHUDs enemyHUD;


    Units playerUnit;
    Units enemyUnit;
    public BattelStates state;
    void Start()
    {
        state = BattelStates.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject PlayerGo = Instantiate(playerPref, playerBattelStation);
        playerUnit = PlayerGo.GetComponent<Units>();

        GameObject EnemyGo = Instantiate(enemPref, enemyBattelStation);
        enemyUnit = EnemyGo.GetComponent<Units>();

        dialogText.text = "Агрессивный " + enemyUnit.unitName + " уже тут! ";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);


        yield return new WaitForSeconds(2f);
        state = BattelStates.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerUltAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.ULTdamage);
        yield return new WaitForSeconds(0f);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogText.text = "Успешная атака!";
        if (isDead)
        {
            state = BattelStates.WON;
            EndBattel();
        }
        else
        {
            state = BattelStates.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyUltTurn()
    {
        dialogText.text = enemyUnit.unitName + "Атакаует!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattelStates.LOST;
            EndBattel();
        }
        else
        {
            state = BattelStates.PLAYERTURN;
            PlayerTurn();
        }

    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogText.text = "Успешная атака!";

        yield return new WaitForSeconds(0f);

        if (isDead)
        {
            state = BattelStates.WON;
            EndBattel();
        }
        else
        {
            state = BattelStates.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        dialogText.text = enemyUnit.unitName + " Атакаует!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattelStates.LOST;
            EndBattel();
        }
        else
        {
            state = BattelStates.PLAYERTURN;
            PlayerTurn();
        }

    }
    void EndBattel()
    {
        if (state == BattelStates.WON)
        {
            dialogText.text = "Вы победили в бою";
        }
        else if (state == BattelStates.LOST)
        {
            dialogText.text = "Вы были повержены";
        }
    }
    void PlayerTurn()
    {
        dialogText.text = "Выберите действие";

    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(playerUnit.HP);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogText.text = "Ваши раны затянулись!";
        yield return new WaitForSeconds(0f);

        state = BattelStates.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }

    public void OnAttackButton()
    {
        if (state != BattelStates.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
    }


    public void OnUltAttackButton()
    {
        if (state != BattelStates.PLAYERTURN)
            return;
        StartCoroutine(PlayerUltAttack());
    }

    public void OnHealButton()
    {
        if (state != BattelStates.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal());
    }

}
