using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public List<LevelSelectObject> levelSelectObjList = new List<LevelSelectObject>();

   public int levelSelectIndex = 0;

   void Start()
   {
      levelSelectObjList[0].Unlock();
   }

   public void CompleteLevel(int levelIndex)
   {
      int nextLevelIndex = levelIndex + 1;

      if (nextLevelIndex >= levelSelectObjList.Count)
      {
         Debug.Log("All levels complete!");
         return;
      }

      levelSelectObjList[nextLevelIndex].Unlock();
   }
}
