using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum NavigationState { BEGINNING, ENTER_ROOM, CHOOSE_PATH}

public class NavigationSystem : MonoBehaviour
{

    private const float PLAYER_POSITION_OFFSET = 0.05F;

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
    private GameObject[] roomList;

    public NavigationState state;

    // Start is called before the first frame update
    void Start()
    {
        startRoom.GetComponent<RoomNode>().HasPlayer = true;

        // create player game object and assign position
        player = Instantiate(playerObject);
        AdjustPlayerPosition(startRoom.transform.position, player);

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

        roomList = new GameObject[11];
        roomList[0] = startRoom;
        roomList[1] = room1;
        roomList[2] = room2;
        roomList[3] = room3;
        roomList[4] = room4;
        roomList[5] = room5;
        roomList[6] = room6;
        roomList[7] = room7;
        roomList[8] = room8;
        roomList[9] = room9;
        roomList[10] = finalRoom;

        state = NavigationState.BEGINNING;
    }

    private void AdjustPlayerPosition(Vector3 roomPosition, GameObject player)
    {
        Vector3 newPosition = roomPosition;
        newPosition.y += PLAYER_POSITION_OFFSET;
        player.transform.position = newPosition;
    }

    private void EnterRoom()
    {
        SceneManager.LoadScene("Combat");
        state = NavigationState.CHOOSE_PATH;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == NavigationState.BEGINNING)
        {
            if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
            {
                Debug.Log("Enter");
                EnterRoom();
            }
        }

        if (state == NavigationState.CHOOSE_PATH)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Debug.Log("Up");
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Down");
            }
        }
    }
}
