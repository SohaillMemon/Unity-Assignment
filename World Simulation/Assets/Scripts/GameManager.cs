using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject WorldCamera;
    [SerializeField] GameObject ThirdPerson;
    [SerializeField] GameObject buttonCanvas;
    [SerializeField] GameObject controlsPanel;
    bool isWorld = true;
    bool objPanel = false;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isWorld ==false)
        {
            WorldCamera.SetActive(true);
            ThirdPerson.SetActive(false);
            buttonCanvas.SetActive(true);
            isWorld = true;
        }

        if(Input.GetKeyDown(KeyCode.C) && objPanel == false)
        {
            controlsPanel.SetActive(true);
            objPanel = true;
        }
        else if(Input.GetKeyDown(KeyCode.C) && objPanel == true)
        {
            controlsPanel.SetActive(false);
            objPanel = false;
        }
    }

    public void PlayNPC()
    {
        WorldCamera.SetActive(false);
        ThirdPerson.SetActive(true);
        buttonCanvas.SetActive(false);
        isWorld = false;
    }
}
