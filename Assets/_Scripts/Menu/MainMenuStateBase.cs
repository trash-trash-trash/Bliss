using UnityEngine;

public class MainMenuStateBase : MonoBehaviour
{
   public MainMenuBrain brain;
   
   public virtual void OnEnable()
   {
      brain = GetComponentInParent<MainMenuBrain>();
   }
}
