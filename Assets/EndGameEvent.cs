using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGameEvent : MonoBehaviour
{
    public UnityEvent endGame;
    public UnityEvent restartGame;
    void Awake()
    {
        if(endGame == null)
        {
            endGame = new UnityEvent();
        }
    }

    public void End()
    {
        endGame.Invoke();
    }

    public void Restart()
    {
        restartGame.Invoke();
    }
}
