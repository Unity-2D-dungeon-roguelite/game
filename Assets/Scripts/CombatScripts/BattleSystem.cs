using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;


	public Transform playerBattleStation;
	public Transform enemyBattleStation1;
	public Transform enemyBattleStation2;
	public Transform enemyBattleStation3;
	public Transform enemyBattleStation4;

	Unit playerUnit;

	Unit enemyUnit1;
	Unit enemyUnit2;
	Unit enemyUnit3;
	Unit enemyUnit4;

	public Text InfoText;

	public BattleHud enemyHud;
	public PlayerHud playerHud;

	public BattleState state;

	Unit selectedEnemy;

	int enemies;
	int damageGiven;
	bool attackReady = false;

	public RectTransform skillsPanel;

	void Start()
    {
		skillsPanel.localScale = new Vector3(0, 0, 0);
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{

		if (enemy1 != null){
			GameObject enemyGO1 = Instantiate(enemy1, enemyBattleStation1);
			enemyUnit1 = enemyGO1.GetComponent<Unit>();
			enemyUnit1.battleSystem = this;
			enemies++;
		}
		if (enemy2 != null){
			GameObject enemyGO2 = Instantiate(enemy2, enemyBattleStation2);
			enemyUnit2 = enemyGO2.GetComponent<Unit>();
			enemyUnit2.battleSystem = this;
			enemies++;
		}
		if (enemy3 != null){
			GameObject enemyGO3 = Instantiate(enemy3, enemyBattleStation3);
			enemyUnit3 = enemyGO3.GetComponent<Unit>();
			enemyUnit3.battleSystem = this;
			enemies++;
		}
		if (enemy4 != null){
			GameObject enemyGO4 = Instantiate(enemy4, enemyBattleStation4);
			enemyUnit4 = enemyGO4.GetComponent<Unit>();
			enemyUnit4.battleSystem = this;
			enemies++;
		}

		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		playerHud.SetupHud(playerUnit);

		InfoText.text = "Test Battle";
		
		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		skillsPanel.localScale = new Vector3(0, 0, 0);
		bool isDead = selectedEnemy.TakeDamage(damageGiven);
		InfoText.text = "The player hits the enemy!";

		yield return new WaitForSeconds(2f);

		if (isDead)
		{
			enemies--;
			selectedEnemy.Remove();
			InfoText.text = "Enemy died";
			if (enemies <= 0)
			{
				state = BattleState.WON;
				EndBattle();
			}
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		InfoText.text = "Enemy turn!";
		yield return new WaitForSeconds(1f);

		if (enemyUnit1 != null){
			InfoText.text = "Enemy 1 attacks!";
			bool isDead = playerUnit.TakeDamage(enemyUnit1.damage);
			playerHud.UpdateHud(playerUnit);
			if (isDead)
			{
				state = BattleState.LOST;
				EndBattle();
			}
			yield return new WaitForSeconds(1f);
		}
		if (enemyUnit2 != null){
			InfoText.text = "Enemy 2 attacks!";
			bool isDead = playerUnit.TakeDamage(enemyUnit2.damage);
			playerHud.UpdateHud(playerUnit);
			if (isDead)
			{
				state = BattleState.LOST;
				EndBattle();
			}
			yield return new WaitForSeconds(1f);
		}
		if (enemyUnit3 != null){
			InfoText.text = "Enemy 3 attacks!";
			bool isDead = playerUnit.TakeDamage(enemyUnit3.damage);
			playerHud.UpdateHud(playerUnit);
			if (isDead)
			{
				state = BattleState.LOST;
				EndBattle();
			}
			yield return new WaitForSeconds(1f);
		}

		if (enemyUnit4 != null){
			InfoText.text = "Enemy 4 attacks!";
			bool isDead = playerUnit.TakeDamage(enemyUnit4.damage);
			playerHud.UpdateHud(playerUnit);
			if (isDead)
			{
				state = BattleState.LOST;
				EndBattle();
			}
		}

		yield return new WaitForSeconds(1f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
		
	}

	void EndBattle() 
	{
		if (state == BattleState.WON)
		{
			InfoText.text = "You won the battle!";
		}
		else if (state == BattleState.LOST)
		{
			InfoText.text = "You were defeated.";
		}
	}

	void PlayerTurn()
	{
	InfoText.text = "Player turn, Select an action";
	}

	public void showInfo(Unit enemy){
		if (state != BattleState.PLAYERTURN || attackReady != true)
			return;
		enemyHud.SetupHud(enemy);
	}

	public void MyAction(Unit enemy){
		if (state != BattleState.PLAYERTURN || attackReady != true){
			return;
		}
		selectedEnemy = enemy;
		attackReady = false;
		StartCoroutine(PlayerAttack());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;
		damageGiven = 5;
		attackReady = true;
		InfoText.text = "Select an enemy";
	}

	public void OnSkillsButton()
	{
		if (state != BattleState.PLAYERTURN)
		{
			return;
		}
		skillsPanel.localScale = new Vector3(1, 1, 1);
	}

	public void OnSkillHaymakerClick()
	{
		if (state != BattleState.PLAYERTURN)
			return;
			
		damageGiven = 8;
		attackReady = true;
		InfoText.text = "Select an enemy";
	}
}
