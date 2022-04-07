using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Paths
{
    private GameObject[] _paths;
    private int _pointer;

    public GameObject[] NextPaths
    {
        get { return _paths; }
        set { _paths = value; }
    }
    public int Selection
    {
        get { return _pointer; }
    }

    public Paths(int length)
    {
        _paths = new GameObject[length];
        _pointer = 0;
    }

    public int CompareTo(GameObject other)
    {
        if (other == null)
        {
            return 1;
        }

        return 0;
    }

    public void SetUpArrowSelect()
    {
        _paths[0].GetComponent<Arrow>().ChangeSprite();
    }

    public void SelectNextArrowDown()
    {
        if (_paths.Length > 1)
        {
            _paths[_pointer].GetComponent<Arrow>().ChangeSprite(); //deselects arrow
            
            //do when down key press on any arrow except on last arrow
            if (_pointer < _paths.Length - 1)
            {
                ++_pointer;
                _paths[_pointer].GetComponent<Arrow>().ChangeSprite(); //selects arrow
            }
            //do when down key press is on last arrow, wrap back to top arrow
            else
            {
                _pointer = 0;
                _paths[_pointer].GetComponent<Arrow>().ChangeSprite(); //selects arrow
            }
        }        
    }

    public void SelectNextArrowUp()
    {
        if (_paths.Length > 1)
        {
            _paths[_pointer].GetComponent<Arrow>().ChangeSprite(); //deselects arrow

            //do when 'up' key press on any arrow except on first arrow
            if (_pointer > 0)
            {
                --_pointer;
                _paths[_pointer].GetComponent<Arrow>().ChangeSprite(); //selects arrow
            }
            //do when up key press is on first arrow, wrap around to bottom arrow
            else
            {
                _pointer = _paths.Length - 1;
                _paths[_pointer].GetComponent<Arrow>().ChangeSprite(); //selects arrow
            }
        }        
    }

    public void DestroyPaths()
    {
        foreach (GameObject path in _paths)
        {
            UnityEngine.Object.Destroy(path);
        }
    }
}
