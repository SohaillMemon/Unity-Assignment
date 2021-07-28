using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    [SerializeField] string sceneName;
    bool isPaused = false;
    [SerializeField] GameObject pausePanel;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            isPaused = true;
        }
      else if (Input.GetKeyDown(KeyCode.P) && isPaused == true)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            isPaused = false;
        }
    }

    public void resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void ExitTomenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update

}
