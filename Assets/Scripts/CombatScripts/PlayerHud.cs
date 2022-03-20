using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    public Text healthText;

    public void SetupHud(Unit unit)
    {
        healthText.text = unit.maxHP + "/" + unit.currentHP;
    }

    public void UpdateHud(Unit unit)
    {
        healthText.text = unit.maxHP + "/" + unit.currentHP;
    }
}
