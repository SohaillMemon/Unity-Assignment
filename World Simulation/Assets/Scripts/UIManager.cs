using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject currentPanel;
    [SerializeField] GameObject otherPanel;
    public bool ispanelOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelOn()
    {
        if(ispanelOn==false)
        {
            currentPanel.SetActive(true);
            otherPanel.SetActive(false);
            ispanelOn = true;
        }
        else
        {
            currentPanel.SetActive(false);
            ispanelOn = false;
        }
    }
}
