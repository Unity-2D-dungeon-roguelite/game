using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player class that will be shared in every scene of the game (static class, only one player)
public class Player : MonoBehaviour
{
    // health point variables
    public static int health = 20;
    public static int maxHealth = 20;
    // stamina variables
    public static int stamina = 20;
    public static int maxStamina = 20;
    // level variable
    public static int level = 1;
    // experience variables
    public static int expNeededLvlUp = 10;
    public static int currentExp = 0;
    // final score variable
    public static int finalScore = 0;

    // static method run everytime experience points are earned for the player
    public static bool levelUp(int experience) 
    {
        int remainingExp = experience + currentExp;
        bool leveledUp = false;

        while (remainingExp >= expNeededLvlUp) {
            remainingExp -= expNeededLvlUp;

            level += 1;
            expNeededLvlUp = (int) System.Math.Round(expNeededLvlUp * 1.2);

            health += 5;
            maxHealth += 5;
            stamina += 2;
            maxStamina += 2;

            leveledUp = true;
        }
        currentExp = remainingExp;

        return leveledUp;
    }
}
