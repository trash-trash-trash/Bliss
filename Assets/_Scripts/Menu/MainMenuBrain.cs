using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum MainMenuStates
{
    PressStart,
    MainMenu,
    LevelSelect,
    TalkToCat,
    Logs,
    InGame,
    Paused,
    Options,
    Quit
}

public class MainMenuBrain : MonoBehaviour
{
    public MainMenuStates currentState;

    public GameObject pressStartObj;
    public GameObject mainMenuObj;
    public GameObject levelSelectObj;
    public GameObject talkToCatObj;
    public GameObject logsObj;
    public GameObject inGameObj;
    public GameObject pausedObj;
    public GameObject optionsObj;
    public GameObject quitObj;
    private GameObject prevObj;

    public Dictionary<MainMenuStates, GameObject> stateDict = new Dictionary<MainMenuStates, GameObject>();

    void Start()
    {
        stateDict.Add(MainMenuStates.PressStart, pressStartObj);
        stateDict.Add(MainMenuStates.MainMenu, mainMenuObj);
        stateDict.Add(MainMenuStates.LevelSelect, levelSelectObj);
        stateDict.Add(MainMenuStates.TalkToCat, talkToCatObj);
        stateDict.Add(MainMenuStates.Logs, logsObj);
        stateDict.Add(MainMenuStates.InGame, inGameObj);
        stateDict.Add(MainMenuStates.Paused, pausedObj);
        stateDict.Add(MainMenuStates.Options, optionsObj);
        stateDict.Add(MainMenuStates.Quit, quitObj);
        ChangeState(MainMenuStates.PressStart);
    }

    public void ChangeState(MainMenuStates newState)
    {
        if (stateDict.TryGetValue(newState, out GameObject obj))
        {
            if (prevObj != null)
            {
                prevObj.SetActive(false);
            }

            prevObj = obj;
            obj.SetActive(true);
            currentState = newState;
        }
    }
}