using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySystem : MonoBehaviour
{
   public void Home()
   {
      SceneManager.LoadScene("Game");
   }

   public void Restart()
   {
      SceneManager.LoadScene("Menu");
   }
}
