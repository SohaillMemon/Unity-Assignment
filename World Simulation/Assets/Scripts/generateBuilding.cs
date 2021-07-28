using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBuilding : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject transparentBuilding;
    public void generatebuilding()
    {
        Instantiate(transparentBuilding);
    }
}
