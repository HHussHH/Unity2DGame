using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Fight
{
    public enum BattelState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
    public class BatteleSystem : MonoBehaviour
    {

        public GameObject pPref;
        public GameObject enemPref;

        public Transform playerBattelStation;
        public Transform enemyBattelStation;

        public Text dialogText;

        public BattleHUD playerHUD;
        public BattleHUD enemyHUD;
        private Animator animator;

        Unit playerUnit;
        Unit enemyUnit;
        public BattelState state;
        void Start()
        {
            state = BattelState.START;
            StartCoroutine(SetupBattle());
            animator = GetComponent<Animator>();
        }

        IEnumerator SetupBattle()
        {
            GameObject PlayerGo = Instantiate(pPref, playerBattelStation);
            playerUnit = PlayerGo.GetComponent<Unit>();

            GameObject EnemyGo = Instantiate(enemPref, enemyBattelStation);
            enemyUnit = EnemyGo.GetComponent<Unit>();

            dialogText.text = "Агрессивный " + enemyUnit.unitName + " уже тут! ";

            playerHUD.SetHUD(playerUnit);
            enemyHUD.SetHUD(enemyUnit);


            yield return new WaitForSeconds(2f);
            state = BattelState.PLAYERTURN;
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
            bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

            enemyHUD.SetHP(enemyUnit.currentHP);
            dialogText.text = "Успешная атака!";

            yield return new WaitForSeconds(0f);

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
                dialogText.text = "Вы победили в бою";
            }
            else if (state == BattelState.LOST)
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

            state = BattelState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }

        public void OnAttackButton()
        {
            if (state != BattelState.PLAYERTURN)
                return;
            animator.Play("blust");
            StartCoroutine(PlayerAttack());
        }


        public void OnUltAttackButton()
        {
            if (state != BattelState.PLAYERTURN)
                return;
            StartCoroutine(PlayerUltAttack());
        }

        public void OnHealButton()
        {
            if (state != BattelState.PLAYERTURN)
                return;
            StartCoroutine(PlayerHeal());
        }

    }
}