using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
    public int selection;
    public int option1;
    public int option2;

    public TMPro.TMP_Text primaryColorText;
    public TMPro.TMP_Text secondColorText;
    public RectTransform selector1;
    public RectTransform selector2;
    public Image selector1Image;
    public Image selector2Image;
    public ChangePlayerColors glimmer;
    public List<Image> primaryColors;
    public List<Image> secondaryColors;
    // Start is called before the first frame update
    void Start()
    {
        Color newPlayer2Color = Customization.ColorCodeToColor(PlayerPrefs.GetString("wall color"));
        
        Color newPlayerColor = Customization.ColorCodeToColor(PlayerPrefs.GetString("glimmer color"));
        glimmer.ChangePrimaryColor(newPlayerColor);
        glimmer.ChangeSecondaryColor(newPlayer2Color);
        option1 = PlayerPrefs.GetInt("option1");
        option2 = PlayerPrefs.GetInt("option2");

        if (option1 == 0)
        {
            selector1.anchoredPosition = new Vector3(-400, 70, 0);
        } else if (option1 == 1)
        {
            selector1.anchoredPosition = new Vector3(-350, 70, 0);
        } else if (option1 == 2)
        {
            selector1.anchoredPosition = new Vector3(-100, 70, 0);
        } else if (option1 == 3)
        {
            selector1.anchoredPosition = new Vector3(50, 70, 0);
        } else if (option1 == 4)
        {
            selector1.anchoredPosition = new Vector3(200, 70, 0);
        }

        if (option2 == 0)
        {
            selector2.anchoredPosition = new Vector3(-400, -70, 0);
        } else if (option2 == 1)
        {
            selector2.anchoredPosition = new Vector3(-250, -70, 0);
        } else if (option2 == 2)
        {
            selector2.anchoredPosition = new Vector3(-100, -70, 0);
        } else if (option2 == 3)
        {
            selector2.anchoredPosition = new Vector3(50, -70, 0);
        } else if (option2 == 4)
        {
            selector2.anchoredPosition = new Vector3(200, -70, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(selection == 0)
        {
            primaryColorText.color = new Color(1, 1, 1, 1);
            secondColorText.color = new Color(1, 1, 1, 0.5f);
            selector1Image.color = new Color(1, 1, 1, 0.5f);
            selector2Image.color = new Color(1, 1, 1, 0.25f);
            if(option1 == 0)
            {
                selector1.anchoredPosition = new Vector3(-400, 70, 0);
            }else if(option1 == 1)
            {
                selector1.anchoredPosition = new Vector3(-250, 70, 0);
            } else if(option1 == 2)
            {
                selector1.anchoredPosition = new Vector3(-100, 70, 0);
            } else if (option1 == 3)
            {
                selector1.anchoredPosition = new Vector3(50, 70, 0);
            } else if(option1 == 4)
            {
                selector1.anchoredPosition = new Vector3(200, 70, 0);
            }
            glimmer.ChangePrimaryColor(primaryColors[option1].color);
        }else if(selection == 1)
        {
            primaryColorText.color = new Color(1, 1, 1, 0.5f);
            secondColorText.color = new Color(1, 1, 1, 1f);

            selector1Image.color = new Color(1, 1, 1, 0.25f);
            selector2Image.color = new Color(1, 1, 1, 0.5f);
            if (option2 == 0)
            {
                selector2.anchoredPosition = new Vector3(-400, -70, 0);
            } else if (option2 == 1)
            {
                selector2.anchoredPosition = new Vector3(-250, -70, 0);
            } else if (option2 == 2)
            {
                selector2.anchoredPosition = new Vector3(-100, -70, 0);
            } else if (option2 == 3)
            {
                selector2.anchoredPosition = new Vector3(50, -70, 0);
            } else if (option2 == 4)
            {
                selector2.anchoredPosition = new Vector3(200, -70, 0);
            }
            glimmer.ChangeSecondaryColor(secondaryColors[option2].color);
        }
    }
    public void Finish()
    {
        PlayerPrefs.SetString("primary color", ColorToColorCode(primaryColors[option1].color));
        PlayerPrefs.SetString("secondary color", ColorToColorCode(secondaryColors[option2].color));

        PlayerPrefs.SetInt("option1", option1);
        PlayerPrefs.SetInt("option2", option2);
        Debug.Log(PlayerPrefs.GetString("primary color"));
        Debug.Log(PlayerPrefs.GetString("secondary color"));
    }
    public static string ColorToColorCode(Color color)
    {
        int r = Mathf.FloorToInt(color.r * 255);
        int g = Mathf.FloorToInt(color.g * 255);
        int b = Mathf.FloorToInt(color.b * 255);
        string rHex = Convert.ToInt32(r).ToString("X");
        string gHex = Convert.ToInt32(g).ToString("X");
        string bHex = Convert.ToInt32(b).ToString("X");
        if(rHex.Length < 2)
        {
            rHex = "0" + rHex;
        }
        if (gHex.Length < 2)
        {
            gHex = "0" + gHex;
        }
        if (bHex.Length < 2)
        {
            bHex = "0" + bHex;
        }
        string colorCode = "" + rHex + gHex + bHex;
        return colorCode;
    }
    public static Color ColorCodeToColor(string color)
    {
        int r = Convert.ToInt32(color.Substring(0, 2), 16);
        int g = Convert.ToInt32(color.Substring(2, 2), 16);
        int b = Convert.ToInt32(color.Substring(4, 2), 16);
        return new Color(r/256f, g/256f, b / 256f, 1);
    }
}
