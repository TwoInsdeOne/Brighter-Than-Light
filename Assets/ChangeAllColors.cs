using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAllColors : MonoBehaviour
{
    public void ChangeAllChildrenColor(Color color)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = color;
        }
    }
}
