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
    public TMP_Text titulo2;
    public AudioSource track;
    public SetSoundVolume trackSetVolume;
    public List<ParticleSystem> psList;
    public List<Vector2> particulas;
    private int lastIndex;

    public TitleControls titleControls;
    public Animator blackscreen;
    public Animator soundtrack;
    private bool startGameTriggered;
    private float startGameTimer;
    // Start is called before the first frame update
    void Start()
    {
        titleControls = new TitleControls();
        titleControls.TitleActions.Enable();
        titleControls.TitleActions.Start.started += StartGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGameTriggered)
        {
            startGameTimer -= Time.deltaTime;
            if(startGameTimer < 0 )
            {
                SceneManager.LoadSceneAsync("Game");
            }
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
        cam.backgroundColor = coresFundo[i];
        titulo.color = coresTitulo[i];
        titulo2.color = coresTitulo[i];
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
    public void StartGame(InputAction.CallbackContext context)
    {
        if (!startGameTriggered)
        {
            blackscreen.SetTrigger("startblackscreen");
            soundtrack.SetTrigger("fadeout");
            startGameTriggered = true;
        }
        
    }
}
