using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;

    public int damage;

    public int maxHP;
    public int currentHP;

	public BattleSystem battleSystem;

	public bool clicked = false;

	//Only for enemy 
	public bool basicAttack;
    public bool idle;
    public bool heal;
    public bool stun;
    public bool staDrain;
    public bool hpDrain;

	public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}
	    public void Remove()
    {
        Destroy(this.gameObject);
    }

	void OnMouseOver(){
		battleSystem.showInfo(this);
	}
	void OnMouseDown(){
		battleSystem.MyAction(this);
	}
}
