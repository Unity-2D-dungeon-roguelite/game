using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const float PLAYER_POSITION_OFFSET = 0.05F;

    private GameObject _player;

    private void Awake()
    {
        _player = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayerOnMap(Vector3 newPosition)
    {
        newPosition.y += PLAYER_POSITION_OFFSET;
        _player.transform.position = newPosition;
    }
}
