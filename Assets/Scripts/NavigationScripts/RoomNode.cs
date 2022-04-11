using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNode : MonoBehaviour
{
    private GameObject[] _nextRooms;

    public GameObject[] NextRooms
    {
        get { return _nextRooms; }
        set { _nextRooms = value; }
    }

    // Start is called before the first frame update, for variable initialization 
    void Start()
    {
        _nextRooms = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
