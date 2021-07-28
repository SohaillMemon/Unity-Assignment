using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    [SerializeField] string sceneName;
  

   public void newgame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
