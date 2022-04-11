using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update.
    /// Credit: https://www.youtube.com/watch?v=HXaFLm3gQws, JTA Games
    /// </summary>
    void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++) { // loops through gameobjects w/ this script
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this) // if not same instance
            {
                if (Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name) // if names are the same
                    Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
