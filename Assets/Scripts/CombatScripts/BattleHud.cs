using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Text nameText;

    public void SetupHud(Unit unit)
    {
        nameText.text = unit.unitName;
    }

    public void UpdateHud(Unit unit)
    {
    }
}
