using UnityEngine;

public class MMTalkToCatState : MainMenuStateBase
{
    public override void OnEnable()
    {
        base.OnEnable();
        brain.backButton.gameObject.SetActive(true);
        brain.backButton.onClick.AddListener(Back);
    }

    public void Back()
    {
        brain.ChangeState(MainMenuStates.MainMenu);
    }

    private void OnDisable()
    {
        brain.backButton.onClick.RemoveListener(Back);
    }
}