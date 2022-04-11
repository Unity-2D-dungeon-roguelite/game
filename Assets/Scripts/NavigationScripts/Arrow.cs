using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Arrow : MonoBehaviour, IComparable<Arrow>
{

    public SpriteRenderer spriteRenderer;
    private bool selected;
    public Sprite unselect;
    public Sprite select;

    /// <summary>
    /// Changes the sprite between of the GameObject depending on its selected state
    /// </summary>
    public void ChangeSprite()
    {
        if (selected is false)
            spriteRenderer.sprite = select;
        else
            spriteRenderer.sprite = unselect;
        
        selected = !selected; // flip the bool
    }

    // Awake is called after all objects are initialized so you can safely speak to other objects 
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        selected = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Compares arrows for iteration.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(Arrow other)
    {
        if (other == null)
        {
            return 1;
        }

        return 0;
    }
}
