using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    public string game;
    public GameObject ressurectionWings;
    public Vector2 playerStartLocation;
    private bool initialized;
    public SoundtrackManager soundtrackManager;

    public EndGameEvent endGameEvent;
    public ChangeAllColors walls;
    public ChangeAllColors playerVisual;
    public ColorChanger playerColorChanger;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        Color newWallColor = Customization.ColorCodeToColor(PlayerPrefs.GetString("wall color"));
        walls.ChangeAllChildrenColor(new Color(newWallColor.r, newWallColor.g, newWallColor.b, 0.68f));
        Color newPlayerColor = Customization.ColorCodeToColor(PlayerPrefs.GetString("glimmer color"));
        playerVisual.ChangeAllChildrenColor( newPlayerColor );
        playerColorChanger.colors[0] = newPlayerColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
        {
            soundtrackManager.Play();
            Time.timeScale = 1.0f;
            initialized = true;
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene(game);
    }
    public void ReloadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
