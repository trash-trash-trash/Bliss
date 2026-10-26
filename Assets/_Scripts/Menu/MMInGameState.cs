using UnityEngine;

public class MMInGameState  : MainMenuStateBase
{
    public override void OnEnable()
    {
        base.OnEnable();
        brain.backButton.gameObject.SetActive(false);
    }
 
}
