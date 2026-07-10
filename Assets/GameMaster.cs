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
    public ChangePlayerColors playerVisual;
    public ColorChanger playerColorChanger;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        Color newSecondaryColor = Customization.ColorCodeToColor(PlayerPrefs.GetString("secondary color"));
        playerVisual.ChangeSecondaryColor(newSecondaryColor);
        Color newPrimaryColor = Customization.ColorCodeToColor(PlayerPrefs.GetString("primary color"));
        playerVisual.ChangePrimaryColor(newPrimaryColor);
        playerColorChanger.colors[0] = newPrimaryColor;
        playerColorChanger.colors[3] = newSecondaryColor;
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
