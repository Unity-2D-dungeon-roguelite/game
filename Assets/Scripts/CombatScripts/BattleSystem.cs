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
	Unit enemyUnit;

	public Text InfoText;

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
			enemyUnit = enemyGO1.GetComponent<Unit>();
		}
		if (enemy2 != null){
			GameObject enemyGO2 = Instantiate(enemy2, enemyBattleStation2);
		}
		if (enemy3 != null){
			GameObject enemyGO3 = Instantiate(enemy3, enemyBattleStation3);
		}
		if (enemy4 != null){
			GameObject enemyGO4 = Instantiate(enemy4, enemyBattleStation4);
		}

		InfoText.text = "Test Battle";

		//enemyHud.SetupHud(enemyUnit);
		//playerHud.SetupHud(playerUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
	}

	IEnumerator PlayerLightAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		//enemyHud.UpdateHud(enemyUnit);
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

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
		//playerHud.UpdateHud(playerUnit);

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

	public void OnLightAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerLightAttack());
	}
}
