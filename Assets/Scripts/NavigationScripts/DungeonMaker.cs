using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaker : MonoBehaviour
{

    public GameObject room;
    private DungeonDirector _director;

    public DungeonDirector Director { 
        get { return _director; } 
        set { _director = value; }
    }
    
    public class DungeonDirector
    {
        DungeonBuilder _builder;
        public GameObject startRoom;

        public DungeonBuilder Builder { get { return _builder; } }

        public DungeonDirector()
        {
            _builder = new DungeonBuilder();
        }

        public List<GameObject> BuildRandomDungeon()
        {
            int methodNumber = UnityEngine.Random.Range(0, DungeonBuilder._NumberOfMethods - 1);
            Debug.Log(methodNumber);
            Func<List<GameObject>> build = _builder.methodMap[methodNumber];
            return build();
        }

    }

    public class DungeonBuilder
    {
        public const int _NumberOfMethods = 4;

        public Dictionary<int, Func<List<GameObject>>> methodMap;
        public GameObject room;

        public DungeonBuilder()
        {
            methodMap = new Dictionary<int, Func<List<GameObject>>>();
            methodMap.Add(0, BuildDungeonOne);
            methodMap.Add(1, BuildDungeonOne);
            methodMap.Add(2, BuildDungeonOne);
            methodMap.Add(3, BuildDungeonOne);
        }

        public List<GameObject> BuildDungeonOne()
        {
            // create rooms       
            GameObject startRoom = Instantiate(room, new Vector3(0, 0, 0), Quaternion.identity);
            startRoom.name = "start room";

            GameObject room1 = Instantiate(room, new Vector3(2, 0, 0), Quaternion.identity);

            GameObject room2 = Instantiate(room, new Vector3(3.5F, 1.4F, 0), Quaternion.identity);
            GameObject room3 = Instantiate(room, new Vector3(3.5F, -1.4F, 0), Quaternion.identity);

            GameObject room4 = Instantiate(room, new Vector3(5, 2.8F, 0), Quaternion.identity);
            GameObject room5 = Instantiate(room, new Vector3(5, 0, 0), Quaternion.identity);
            GameObject room6 = Instantiate(room, new Vector3(5, -2.8F, 0), Quaternion.identity);

            GameObject room7 = Instantiate(room, new Vector3(6.5F, 1.4F, 0), Quaternion.identity);
            GameObject room8 = Instantiate(room, new Vector3(6.5F, -1.4F, 0), Quaternion.identity);

            GameObject room9 = Instantiate(room, new Vector3(8, 0, 0), Quaternion.identity);

            GameObject finalRoom = Instantiate(room, new Vector3(10, 0, 0), Quaternion.identity);

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

            List<GameObject> roomList = new List<GameObject>();
            roomList.Add(startRoom);
            roomList.Add(room1);
            roomList.Add(room2);
            roomList.Add(room3);
            roomList.Add(room4);
            roomList.Add(room5);
            roomList.Add(room6);
            roomList.Add(room7);
            roomList.Add(room8);
            roomList.Add(room9);
            roomList.Add(finalRoom);

            return roomList;
        }

        public void BuildDungeonTwo()
        {

        }

        public void BuildDungeonThree()
        {

        }

        public void BuildDungeonFour()
        {

        }
    }

    private void Awake()
    {
        DungeonDirector sample = new DungeonDirector();
        this.Director = sample;
        sample.Builder.room = room;
    }

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
