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

	public BattleState state;

	void Start()
    {

		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{

		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);

		if (enemy1 != null){
			GameObject enemyGO1 = Instantiate(enemy1, enemyBattleStation1);
			enemyUnit1 = enemyGO1.GetComponent<Unit>();
			enemyUnit1.battleSystem = this;
		}
		if (enemy2 != null){
			GameObject enemyGO2 = Instantiate(enemy2, enemyBattleStation2);
			enemyUnit2 = enemyGO2.GetComponent<Unit>();
			enemyUnit2.battleSystem = this;
		}
		if (enemy3 != null){
			GameObject enemyGO3 = Instantiate(enemy3, enemyBattleStation3);
			enemyUnit3 = enemyGO3.GetComponent<Unit>();
			enemyUnit3.battleSystem = this;
		}
		if (enemy4 != null){
			GameObject enemyGO4 = Instantiate(enemy4, enemyBattleStation4);
			enemyUnit4 = enemyGO4.GetComponent<Unit>();
			enemyUnit4.battleSystem = this;
		}

		InfoText.text = "Test Battle";
		
		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerLightAttack()
	{
		bool isDead = enemyUnit1.TakeDamage(playerUnit.damage);
		InfoText.text = "The player hits the enemy!";

		yield return new WaitForSeconds(2f);

		if (isDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{

		InfoText.text = "The enemy attacks the player!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit1.damage);

		yield return new WaitForSeconds(1f);

		if (isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}
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
	InfoText.text = "Player turn";
	}

	public void MyAction(Unit enemy){
		InfoText.text = "Clicked";
		if (state != BattleState.PLAYERTURN){
			return;
		}
		enemyHud.SetupHud(enemy);
	}

	public void OnLightAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerLightAttack());
	}
}
