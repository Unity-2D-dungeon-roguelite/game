using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Text nameText;
    public Text healthText;

    public void SetupHud(Unit unit)
    {
        nameText.text = unit.unitName;
        healthText.text = unit.currentHP + "/" + unit.maxHP;
    }

    public void UpdateHud(Unit unit)
    {
        healthText.text = unit.currentHP + "/" + unit.maxHP;
    }
}
