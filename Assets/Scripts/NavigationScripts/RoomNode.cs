using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNode : MonoBehaviour
{

    private bool _hasPlayer;
    private GameObject[] _nextRooms = null;

    public bool HasPlayer
    {
        get { return _hasPlayer; }
        set { _hasPlayer = value; }
    }

    public GameObject[] NextRooms
    {
        get { return _nextRooms; }
        set { _nextRooms = value; }
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
