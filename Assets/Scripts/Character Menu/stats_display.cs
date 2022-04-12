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
        GameObject.Find("NavigationSystem").GetComponent<NavigationSystem>().enabled = false;
        //nav.GetComponent<NavigationSystem>().enabled
        hpText.text = Player.health.ToString() + " / " + Player.maxHealth.ToString();
        staminaText.text = Player.stamina.ToString() + " / " + Player.maxStamina.ToString();
        levelText.text = Player.level.ToString();
    }

    public void Update()
    {
        if ( Input.GetKey(KeyCode.M) || Input.GetKey(KeyCode.Escape) )
        {
            // Exit Menu screen, back to navigation
            GameObject.Find("NavigationSystem").GetComponent<NavigationSystem>().enabled = true;
            SceneManager.LoadScene(1);
        }
    }

    
}
