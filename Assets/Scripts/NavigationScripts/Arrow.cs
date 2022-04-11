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

    public void ChangeSprite()
    {
        if (selected is false)
            spriteRenderer.sprite = select;
        else
            spriteRenderer.sprite = unselect;
        
        selected = !selected;
    }

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

    public int CompareTo(Arrow other)
    {
        if (other == null)
        {
            return 1;
        }

        return 0;
    }
}
