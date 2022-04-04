using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Unit
{
    
    public List<System.Action> actions = new List<System.Action>();

    void Start()
    {
        actions.Add(attack);
        actions.Add(stare);
    }
    
    public void attack(){
        bool isDead = battleSystem.playerUnit.TakeDamage(this.damage);
        battleSystem.playerHud.UpdateHud(battleSystem.playerUnit);
    }
    public void stare(){
        battleSystem.InfoText.text = "The Skeleton stares at you";
    }
}
