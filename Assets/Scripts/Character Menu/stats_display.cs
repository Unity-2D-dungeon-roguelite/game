using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stats_display : MonoBehaviour
{
    public Text hpText;
    public Text staminaText;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = Player.health.ToString() + " / " + Player.maxHealth.ToString();
        staminaText.text = Player.stamina.ToString() + " / " + Player.maxStamina.ToString();
        levelText.text = Player.level.ToString();
    }

    public void Update()
    {
        if ( Input.GetKey(KeyCode.M) || Input.GetKey(KeyCode.Escape) )
        {
            // Exit Menu screen, back to navigation
            SceneManager.LoadScene(1);
        }
    }

    
}
