﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
   public void GoToScene()
   {
      SceneManager.LoadScene(1);
   }

   public void Quit()
   {
      Application.Quit();
   }

}
