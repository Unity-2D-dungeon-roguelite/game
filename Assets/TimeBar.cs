using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{

    public Image image;
    
    public void MovePlayer(int amount){
        Vector3 pos = image.GetComponent<RectTransform>().anchoredPosition;
        pos.x += amount;
        image.GetComponent<RectTransform>().anchoredPosition = pos;
    }
    
}
