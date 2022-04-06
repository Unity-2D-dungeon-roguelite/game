using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    public Text healthText;
    public Text staminaText;

    public void SetupHud(Unit unit)
    {
        healthText.text = "HP:" + unit.currentHP + "/" + unit.maxHP;
        staminaText.text = "STA:" + unit.currentSta + "/" + unit.maxSta;
    }

    public void UpdateHud(Unit unit)
    {
        healthText.text = "HP:" + unit.currentHP + "/" + unit.maxHP;
        staminaText.text = "STA:" + unit.currentSta + "/" + unit.maxSta;
    }
}