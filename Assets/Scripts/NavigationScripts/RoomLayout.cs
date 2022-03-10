using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLayout : MonoBehaviour
{

    public GameObject room;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // create rooms
        GameObject startRoom = Instantiate(room, new Vector3(-5, 0, 0), Quaternion.identity) as GameObject;

        GameObject room1 = Instantiate(room, new Vector3(-3, 0, 0), Quaternion.identity) as GameObject;

        GameObject room2 = Instantiate(room, new Vector3(-1.5F, 1.4F, 0), Quaternion.identity) as GameObject;
        GameObject room3 = Instantiate(room, new Vector3(-1.5F, -1.4F, 0), Quaternion.identity) as GameObject;

        GameObject room4 = Instantiate(room, new Vector3(0, 2.8F, 0), Quaternion.identity) as GameObject;
        GameObject room5 = Instantiate(room, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        GameObject room6 = Instantiate(room, new Vector3(0, -2.8F, 0), Quaternion.identity) as GameObject;

        GameObject room7 = Instantiate(room, new Vector3(1.5F, 1.4F, 0), Quaternion.identity) as GameObject;
        GameObject room8 = Instantiate(room, new Vector3(1.5F, -1.4F, 0), Quaternion.identity) as GameObject;

        GameObject room9 = Instantiate(room, new Vector3(3, 0, 0), Quaternion.identity) as GameObject;

        GameObject room10 = Instantiate(room, new Vector3(5, 0, 0), Quaternion.identity) as GameObject;

        // assign rooms' next rooms (for selecting which room to go later)
        startRoom.GetComponent<RoomNode>().NextRooms = new GameObject[] { room1 };
        room1.GetComponent<RoomNode>().NextRooms = new GameObject[] { room2, room3 };
        room2.GetComponent<RoomNode>().NextRooms = new GameObject[] { room4, room5 };
        room3.GetComponent<RoomNode>().NextRooms = new GameObject[] { room5, room6 };
        room4.GetComponent<RoomNode>().NextRooms = new GameObject[] { room7 };
        room5.GetComponent<RoomNode>().NextRooms = new GameObject[] { room7, room8 };
        room6.GetComponent<RoomNode>().NextRooms = new GameObject[] { room8 };
        room7.GetComponent<RoomNode>().NextRooms = new GameObject[] { room9 };
        room8.GetComponent<RoomNode>().NextRooms = new GameObject[] { room9 };
        room9.GetComponent<RoomNode>().NextRooms = new GameObject[] { room10 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
