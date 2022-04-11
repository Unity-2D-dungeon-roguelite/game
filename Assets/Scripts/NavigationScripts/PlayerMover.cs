using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const float PLAYER_POSITION_OFFSET = 0.05F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Changes the player's icon location to a new position.
    /// </summary>
    /// <param name="newPosition"> Vector3 </param>
    public void MovePlayerOnMap(Vector3 newPosition)
    {
        newPosition.y += PLAYER_POSITION_OFFSET;
        gameObject.transform.position = newPosition;
    }
}
