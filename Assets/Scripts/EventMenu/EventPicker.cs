using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventPicker : MonoBehaviour
{
    // scene text objects
    public Text event_text;
    public Text result_text;
    // current number of implemented events
    private static int event_max = 7;
    private int random_event_num = 1;

    private void change_event_text(int event_num) 
    {
        string event_string = "";
        string result_string = "";

        switch (event_num) {
            case 1:
                event_string = "You enter an ominous room, filled with many bones and skeletons of possibly former adventurers...but why are they moving? 4 skeletons reconstuct and emerge in front of you, eager to turn you into one of them.";
                result_string = "Prepare for a battle encounter!";
                break;
            case 2:
                event_string = "You enter a dark room filled with...nothingness, for better or for worse.";
                result_string = "Continue forward!";
                break;
            case 3:
                event_string = "You enter a seemlingly harmless room without any dangers, that is, until you stepped on an invisible floor trap that sent you down a pile of other fallen adventurers who made the same mistake you did. Fortunately, you were able to climb yourself out of the trap this time...";
                result_string = "Health - 1";
                break;
            case 4:
                event_string = "You enter room filled with noxious gas. You didn't notice until it was too late but managed hold your breath, sprint out, and live to see another day.";
                result_string = "Health -5";
                break;
            case 5:
                event_string = "You enter a room with a singluar tree that managed to survive with an odd light source emitting from the top of the room. It even bears some apples, which you decide to eat.";
                result_string = "stamina + 3";
                break;
            case 6:
                event_string = "You find a fallen adventurer that has ran out of luck it seems. Fortunately, they carry some rations that you deem still edible for the road ahead.";
                result_string = "Stamina + 5";
                break;
            case 7:
                event_string = "You enter a flooded room, filled with a mysterious liquid that seems to calm your mind as you make your way through to the exit.";
                result_string = "Health + 5";
                break;
        }

        event_text.text = event_string;
        result_text.text = result_string;
    }

    private void result_event(int event_num) 
    {
        switch (event_num)
        {
            case 1:
                // Enter combat scene
                SceneManager.LoadScene(2);
                break;
            case 2:
                break;
            case 3:
                Player.health -= 1;
                break;
            case 4:
                Player.health -= 5;
                break;
            case 5:
                Player.stamina += 3;
                break;
            case 6:
                Player.stamina += 5;
                break;
            case 7:
                Player.health += 5;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("NavigationSystem").GetComponent<NavigationSystem>().enabled = false;

        random_event_num = Random.Range(1, event_max);  
        // display random event text
        change_event_text(random_event_num);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter " + Time.frameCount);
            // Exit event screen, back to navigation
            result_event(random_event_num);
            // Return to navigation scene
            GameObject.Find("NavigationSystem").GetComponent<NavigationSystem>().enabled = true;
            SceneManager.LoadScene(1);
        }
    }
}
