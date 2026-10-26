using UnityEngine;
using UnityEngine.UI;

public class LevelSelectObject : MonoBehaviour
{
    public Button levelSelectButton;
    public bool locked = true;

    public void Unlock()
    {
        locked = false;
        levelSelectButton.interactable = true;
    }
}
