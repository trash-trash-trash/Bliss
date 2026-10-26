using UnityEngine;

public class MMPressStartState : MainMenuStateBase
{
    public override void OnEnable()
    {
        base.OnEnable();
        brain.backButton.gameObject.SetActive(false);
        PlayerControls.Instance.AnnounceAnyKeyPressedReleased += ChangeState;
    }

    private void ChangeState(bool obj)
    {
        if(!obj)
            brain.ChangeState(MainMenuStates.MainMenu);
    }

    void OnDisable()
    {
        PlayerControls.Instance.AnnounceAnyKeyPressedReleased -= ChangeState;
    }
}