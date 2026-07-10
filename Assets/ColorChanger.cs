using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public List<Color> colors;
    public List<SpriteRenderer> primaryParts;
    public List<SpriteRenderer> secondaryParts;

    public void ChangePrimaryToColor(int colorId)
    {
        foreach (var part in primaryParts)
        {
            part.color = colors[colorId];
        }
    }
    public void ChangeSecondaryToColor(int colorId)
    {
        foreach (var part in secondaryParts)
        {
            part.color = colors[colorId];
        }
    }
}
