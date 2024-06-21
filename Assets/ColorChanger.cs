using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public List<Color> colors;
    public List<SpriteRenderer> parts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeToColor(int colorId)
    {
        foreach (var part in parts)
        {
            part.color = colors[colorId];
        }
    }
}
