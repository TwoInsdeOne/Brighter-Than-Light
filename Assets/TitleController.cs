using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public Volume volume;
    public List<VolumeProfile> profiles;
    public int currentProfile;
    public List<Color> cores;
    public Camera cam;
    public List<Color> coresFundo;
    public List<Color> coresTitulo;
    //public TextMeshPro titulo;
    public TMPro.TMP_Text titulo;
    public TMP_Text startGameText;
    public AudioSource track;
    public SetSoundVolume trackSetVolume;
    public List<ParticleSystem> psList;
    public List<Vector2> particulas;
    private int lastIndex;

    public SpriteRenderer background;

    public TitleControls titleControls;
    public Animator blackscreen;
    public Animator soundtrack;
    private bool startGameTriggered;
    public float startGameTimer;
    private bool gameStarted;

    public AudioSource lightsound;

    public AudioSource lightsound2;

    public Customization customization;
    public int option;
    public Animator cameraAnimator;
    public TMP_Text customizeText;
    // Start is called before the first frame update
    void Start()
    {
        titleControls = new TitleControls();
        titleControls.TitleActions.Enable();
        titleControls.TitleActions.Start.started += SelectOptionOnTitle;
        titleControls.TitleActions.Up.started += Option0;
        titleControls.TitleActions.Down.started += Option1;
        titleControls.CustomizeAction.Disable();
        titleControls.CustomizeAction.Finish.started += FinishCustomization;
        titleControls.CustomizeAction.Up.started += CustomizeUp;
        titleControls.CustomizeAction.Down.started += CustomizeDown;
        titleControls.CustomizeAction.Left.started += CustomizeLeft;
        titleControls.CustomizeAction.Right.started += CustomizeRight;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGameTriggered && !gameStarted)
        {
            startGameTimer -= Time.deltaTime;
            if(startGameTimer < 0 )
            {
                gameStarted = true;
                SceneManager.LoadScene("Game");
            }
        }
        if(option == 0)
        {
            startGameText.color = new Color(startGameText.color.r, startGameText.color.g, startGameText.color.b, 1f);
            customizeText.color = new Color(startGameText.color.r, startGameText.color.g, startGameText.color.b, 0.4f);
        } else if(option == 1)
        {
            customizeText.color = new Color(startGameText.color.r, startGameText.color.g, startGameText.color.b, 1f);
            startGameText.color = new Color(startGameText.color.r, startGameText.color.g, startGameText.color.b, 0.4f);
        }
    }
    public void SetNextProfile()
    {
        volume.profile = profiles[(currentProfile + 1) % profiles.Count];
    }
    public void Marcas(int i)
    {
        
        if(lastIndex == 12)
        {
            lastIndex = 0;
            return;
        }
        if (i == 0)
        {
            soundtrack.SetTrigger("fadein");
        }
        if (!track.isPlaying)
        {
            track.Play();
        }
        //cam.backgroundColor = coresFundo[i];
        background.color = coresFundo[i];
        titulo.color = coresTitulo[i];
        startGameText.color = new Color(coresTitulo[i].r, coresTitulo[i].g, coresTitulo[i].b, startGameText.color.a);
        for (int j = 0; j < psList.Count; j++)
        {
            psList[j].gameObject.SetActive(false);
        }
        if (particulas[i].x >= 0)
        {
            psList[(int)particulas[i].x].gameObject.SetActive(true);
        }
        if (particulas[i].y >= 0)
        {
            psList[(int)particulas[i].y].gameObject.SetActive(true);
        }

        lastIndex = i;

    }
    public void SetVolumeAndPlay()
    {
        track.Stop();
        track.Play();
        trackSetVolume.SetVolume(0.8f);
    }
    public void Option0(InputAction.CallbackContext context)
    {
        option = 0;
    }
    public void Option1(InputAction.CallbackContext context)
    {
        option = 1;
    }
    public void SelectOptionOnTitle(InputAction.CallbackContext context)
    {
        if(option == 0)
        {
            StartGame();
        } else if(option == 1)
        {
            cameraAnimator.SetInteger("position", 1);
            titleControls.TitleActions.Disable();
            titleControls.CustomizeAction.Enable();
        }
    }
    public void StartGame()
    {
        if (!startGameTriggered)
        {
            titleControls.Disable();
            lightsound.Play();
            blackscreen.SetTrigger("startblackscreen");
            soundtrack.SetTrigger("fadeout");
            startGameTriggered = true;
        }
    }
    public void FinishCustomization(InputAction.CallbackContext context)
    {
        customization.Finish();
        lightsound2.Play();
        cameraAnimator.SetInteger("position", 0);
        titleControls.TitleActions.Enable();
        titleControls.CustomizeAction.Disable();
    }
    public void CustomizeUp(InputAction.CallbackContext context)
    {
        if(customization.selection == 0)
        {
            customization.selection = 1;
        } else
        {
            customization.selection = (customization.selection - 1) % 2;
        }
        
    }
    public void CustomizeDown(InputAction.CallbackContext context)
    {
        customization.selection = (customization.selection + 1) % 2;
    }
    public void CustomizeLeft(InputAction.CallbackContext context)
    {
        if(customization.selection == 0)
        {
            if(customization.option1 == 0)
            {
                customization.option1 = 4;
            } else
            {
                customization.option1 = (customization.option1 - 1) % 5;
            }
            
        } else if(customization.selection == 1)
        {
            if (customization.option2 == 0)
            {
                customization.option2 = 4;
            } else
            {
                customization.option2 = (customization.option2 - 1) % 5;
            }
            
        }
    }
    public void CustomizeRight(InputAction.CallbackContext context)
    {
        if (customization.selection == 0)
        {
            customization.option1 = (customization.option1 + 1) % 5;
        } else if (customization.selection == 1)
        {
            customization.option2 = (customization.option2 + 1) % 5;
        }
    }
}
