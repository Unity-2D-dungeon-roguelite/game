using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Text nameText;
    public Text HPText;

    public void SetupHud(Unit unit)
    {
        nameText.text = unit.unitName;
        HPText.text = unit.currentHP + "/" + unit.maxHP;
    }

    public void UpdateHud(Unit unit)
    {
    }
}
