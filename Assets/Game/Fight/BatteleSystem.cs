using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum BattelState {START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BatteleSystem : MonoBehaviour
{

    public Button GameWin;
    public GameObject playerPref;
    public GameObject enemPref;

    public Transform playerBattelStation;
    public Transform enemyBattelStation;

    public Text dialogText;
    public TMP_Text Gem;
    public TMP_Text boss;
    public TMP_Text PlayerGame;
    private float coins = 250;
    private float coinsL = -20;
    private int bosscount = 1;

    public BattleHUDs playerHUD;
    public BattleHUDs enemyHUD;

    public test parse;
    public AudioClip clipHEAL;
    public AudioClip clipAttack;
    public AudioClip clipULT;

    Units playerUnit;
    Units enemyUnit;
    public BattelState state;
    void Start()
    {
        GameWin.gameObject.SetActive(true);
        state = BattelState.START;
        StartCoroutine(SetupBattle());
    }
    private void Update()
    {
        PlayerGame.text = Gem.text;
    }

    IEnumerator SetupBattle()
    {
        GameObject PlayerGo =  Instantiate(playerPref, playerBattelStation);
        playerUnit =  PlayerGo.GetComponent<Units>();

        GameObject EnemyGo = Instantiate(enemPref, enemyBattelStation);
        enemyUnit = EnemyGo.GetComponent<Units>();

        dialogText.text = "Агрессивный " + enemyUnit.unitName +" уже тут! ";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);


        yield return new WaitForSeconds(2f);
        dialogText.text = "Твоя смерть близка";
        yield return new WaitForSeconds(2f);
        state = BattelState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerUltAttack()
    {
        GetComponent<AudioSource>().PlayOneShot(clipULT);
        bool isDead = enemyUnit.TakeDamage(playerUnit.ULTdamage);
        yield return new WaitForSeconds(0f);
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogText.text = "Успешная атака!";
        if (isDead)
        {
            state = BattelState.WON;
            EndBattel();
        }
        else
        {
            state = BattelState.ENEMYTURN;
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
            state = BattelState.LOST;
            EndBattel();
        }
        else
        {
            state = BattelState.PLAYERTURN;
            PlayerTurn();
        }

    }

    IEnumerator PlayerAttack()
    {
        GetComponent<AudioSource>().PlayOneShot(clipAttack);
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogText.text = "Успешная атака!";

        yield return new WaitForSeconds(0f);

        if(isDead)
        {
            state = BattelState.WON;
            EndBattel();
        }
        else
        {
            state = BattelState.ENEMYTURN;
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
            state = BattelState.LOST;
            EndBattel();
        }
        else
        {
            state = BattelState.PLAYERTURN;
            PlayerTurn();
        }

    }
    void EndBattel()
    {
        if (state == BattelState.WON)
        {
            GameWin.gameObject.SetActive(true);
            float win = float.Parse(Gem.text) + coins;
            Gem.text = win.ToString();

            int con = int.Parse(boss.text) + bosscount;
            boss.text = con.ToString();

            dialogText.text = "Вы победили в бою";
        }
        else if (state == BattelState.LOST)
        {
            GameWin.gameObject.SetActive(true);
            float win = float.Parse(Gem.text) + coinsL ;
            Gem.text = win.ToString();
            dialogText.text = "Вы были повержены";
            
        }
    }
    void PlayerTurn()
    {
        dialogText.text = "Выберите действие";
            
    }

    IEnumerator PlayerHeal()
    {
        GetComponent<AudioSource>().PlayOneShot(clipHEAL);
        playerUnit.Heal(playerUnit.HP);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogText.text = "Ваши раны затянулись!";
        yield return new WaitForSeconds(0f);

        state = BattelState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }

    public void OnAttackButton()
    {
        if (state != BattelState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
    }

 
    public void OnUltAttackButton()
    {
        if (state != BattelState.PLAYERTURN)
            return;
        if(int.Parse(PlayerGame.text) < 20)
        {
            dialogText.text = "У вас слишком мало гемов!";
        }
        else
        {
            dialogText.text = "У вас исчезло 20 гемов";
            float minus = float.Parse(Gem.text) - 20;
            Gem.text = minus.ToString();
            StartCoroutine(PlayerUltAttack());
        }
        
    }

    public void OnHealButton()
    {
        if (state != BattelState.PLAYERTURN)
            return;
        if (int.Parse(PlayerGame.text) < 5)
        {
            dialogText.text = "У вас слишком мало гемов!";
        }
        else
        {
            dialogText.text = "У вас исчезло 5 гемов";
            float minus = float.Parse(Gem.text) - 5;
            Gem.text = minus.ToString();
            StartCoroutine(PlayerHeal());
        }
    }

    public void onButtonEndS()
    {
        if(state == BattelState.LOST)
        {
            state = BattelState.START;
            StartCoroutine(SetupBattle());
        }
    }

}
