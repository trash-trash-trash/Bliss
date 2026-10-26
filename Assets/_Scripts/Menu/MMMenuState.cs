using UnityEngine;

public class MMMenuState : MainMenuStateBase
{
    public GameObject mainMenuCanvasObj;
    
    public override void OnEnable()
    {
        base.OnEnable();
        mainMenuCanvasObj.SetActive(true);
        brain.backButton.gameObject.SetActive(false);
    }

    public void LevelSelect()
    {
        brain.ChangeState(MainMenuStates.LevelSelect);
    }

    public void TalkToCat()
    {
        brain.ChangeState(MainMenuStates.TalkToCat);
    }

    public void Logs()
    {
        brain.ChangeState(MainMenuStates.Logs);
    }

    public void Options()
    {
        brain.ChangeState(MainMenuStates.Options);
    }

    public void Quit()
    {
        brain.ChangeState(MainMenuStates.Quit);
    }

    void OnDisable()
    {
        mainMenuCanvasObj.SetActive(false);
    }
}