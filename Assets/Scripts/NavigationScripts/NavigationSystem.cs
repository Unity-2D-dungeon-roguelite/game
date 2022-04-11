using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum NavigationState { ROOM_EVENT, CHOOSE_PATH, END}

public class NavigationSystem : MonoBehaviour
{

    private const float PLAYER_POSITION_OFFSET = 0.05F;
    private const int UPWARD_ROTATION = -45;
    private const int DOWNWARD_ROTATION = -135;

    //put in dungeon factory later
    public const float ROOM_X_DISTANCE = 1.5F;
    public const float ROOM_Y_DISTANCE = 1.4F;
    public const int ONE_ROOM_ARROW_X_DISTANCE = 1;
    public const float ARROW_X_DISTANCE = 0.75F;
    public const float ARROW_Y_DISTANCE = 0.7F;

    public GameObject startRoom;
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public GameObject room4;
    public GameObject room5;
    public GameObject room6;
    public GameObject room7;
    public GameObject room8;
    public GameObject room9;
    public GameObject finalRoom;
    public GameObject playerObject;
    public GameObject arrow;
    public GameObject player;
    private GameObject playerRoom;

    //state variables
    public NavigationState state;
    private bool playerSelection = false;
    Paths paths;

    // Start is called before the first frame update
    void Start()
    {
        playerRoom = startRoom;

        // create player game object and assign position
        player = Instantiate(playerObject);
        //AdjustPlayerPosition(startRoom.transform.position, player);
        player.GetComponent<PlayerMover>().MovePlayerOnMap(startRoom.transform.position);

        // assign rooms' next rooms to traverse
        startRoom.GetComponent<RoomNode>().NextRooms = new GameObject[] { room1 };
        room1.GetComponent<RoomNode>().NextRooms = new GameObject[] { room2, room3 };
        room2.GetComponent<RoomNode>().NextRooms = new GameObject[] { room4, room5 };
        room3.GetComponent<RoomNode>().NextRooms = new GameObject[] { room5, room6 };
        room4.GetComponent<RoomNode>().NextRooms = new GameObject[] { room7 };
        room5.GetComponent<RoomNode>().NextRooms = new GameObject[] { room7, room8 };
        room6.GetComponent<RoomNode>().NextRooms = new GameObject[] { room8 };
        room7.GetComponent<RoomNode>().NextRooms = new GameObject[] { room9 };
        room8.GetComponent<RoomNode>().NextRooms = new GameObject[] { room9 };
        room9.GetComponent<RoomNode>().NextRooms = new GameObject[] { finalRoom };

        state = NavigationState.ROOM_EVENT;
    }

    private void EnterRoom()
    {
        // Load room scene
        //SceneManager.LoadScene("Combat");
    }

    /// <summary>
    /// Returns the appropriate arrows pointing to the next rooms.
    /// </summary>
    /// <returns></returns>
    private Paths GeneratePaths()
    {
        // instance properties of arrow
        float xDistance;
        float yDistance;
        int rotation;

        GameObject arrowObject;
        Paths generatedPaths = new Paths(playerRoom.GetComponent<RoomNode>().NextRooms.Length);

        int count = 0;

        foreach (GameObject room in playerRoom.GetComponent<RoomNode>().NextRooms) // looks at each next room
        {
            if (room.transform.position.y > playerRoom.transform.position.y) // if the next room is above player room (current room)
            {
                // set variables to appropriate values depending where is next room
                xDistance = playerRoom.transform.position.x + ARROW_X_DISTANCE;
                yDistance = playerRoom.transform.position.y + ARROW_Y_DISTANCE;
                rotation = UPWARD_ROTATION;

                // make room and rotate it accordingly
                arrowObject = Instantiate(arrow, new Vector3(xDistance, yDistance, 0), Quaternion.identity);
                arrowObject.transform.Rotate(0, 0, rotation);
            }
            else if (room.transform.position.y < playerRoom.transform.position.y)
            {
                // set variables to appropriate values depending where is next room
                xDistance = playerRoom.transform.position.x + ARROW_X_DISTANCE;
                yDistance = playerRoom.transform.position.y - ARROW_Y_DISTANCE;
                rotation = DOWNWARD_ROTATION;

                // make room and rotate it accordingly
                arrowObject = Instantiate(arrow, new Vector3(xDistance, yDistance, 0), Quaternion.identity);
                arrowObject.transform.Rotate(0, 0, rotation);
            }
            else
            {
                // set variables to appropriate values depending where is next room
                xDistance = playerRoom.transform.position.x + ONE_ROOM_ARROW_X_DISTANCE;
                // make room and rotate it accordingly
                arrowObject = Instantiate(arrow, new Vector3(xDistance, 0, 0), Quaternion.identity);
                arrowObject.transform.Rotate(0f, 0f, -90f);
            }

            generatedPaths.NextPaths[count] = arrowObject; // arrow object is added to next paths to later display
            ++count;
        }

        return generatedPaths;
    }

    // Update is called once per frame
    void Update()
    {
        //room event state
        if (state == NavigationState.ROOM_EVENT)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Enter " + Time.frameCount);
                EnterRoom();
                state = NavigationState.CHOOSE_PATH; // after room scene, choose next paths
            }

            else if (Input.GetKey(KeyCode.M))
            {
                // Load Menu Screen
                SceneManager.LoadScene(3);
            }
        }

        //when choosing next room
        else if (state == NavigationState.CHOOSE_PATH)
        {            
            if (playerSelection is true && Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Up");
                paths.SelectNextArrowUp(); //selects new arrow upwards
            }

            else if (playerSelection is true && Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Down");
                paths.SelectNextArrowDown(); //selects new arrow downwards
            }

            // when user hits enter on a selected path
            else if (playerSelection is true && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
            {
                Debug.Log("Next room selected " + Time.frameCount);

                playerRoom = playerRoom.GetComponent<RoomNode>().NextRooms[paths.Selection]; // assigns player room to room selected
                player.GetComponent<PlayerMover>().MovePlayerOnMap(playerRoom.transform.position);

                playerSelection = false;
                paths.DestroyPaths();
                state = NavigationState.ROOM_EVENT; // enter room after chosen
            }

            else if (playerSelection is false && playerRoom.GetComponent<RoomNode>().NextRooms != null)
            {
                paths = GeneratePaths();
                paths.SetUpArrowSelect(); // set top arrow as selected
                playerSelection = true; // phase where player is selecting a path
            }

            else if (playerSelection is false && playerRoom.GetComponent<RoomNode>().NextRooms == null)
            {
                state = NavigationState.END;
            }
        }

        //when at last room (final boss)
        else if (state == NavigationState.END)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Enter final room");
                EnterRoom();
                Application.Quit();
            }

            else if (Input.GetKey(KeyCode.M))
            {
                // Load Menu Screen
                SceneManager.LoadScene(3);
            }

        }
    }
}
