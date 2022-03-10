using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // create position for player
        Vector3 position = startRoom.transform.position;
        position.y += PLAYER_POSITION_OFFSET;

        // create player game object and assign position
        Instantiate(player);
        player.transform.position = position;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
