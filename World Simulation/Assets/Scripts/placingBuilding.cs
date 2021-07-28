using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placingBuilding : MonoBehaviour
{
    public GameObject mainBuilding;
    public LayerMask layermask;
    public LayerMask obstacleMask;
    RaycastHit hit;
    bool canPlace = true;
    float i = 0;
    public AIControlle agent;
    // Start is called before the first frame update
    void Start()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if(Physics.Raycast(ray,out hit, 50000f, layermask))
        //{
        //    transform.position = hit.point;
        //}
        i = transform.rotation.y;
        agent = FindObjectOfType<AIControlle>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000f))
        {
            if(hit.collider.CompareTag("Terrain"))
            {
                transform.position = hit.point;
                canPlace = true;
            }

            else
            {
                canPlace = false;
                transform.position = hit.point;
            }
            //canPlace = true;
            //transform.position = hit.point;    
            
        }
        //else if (Physics.Raycast(ray,out hit, 50000f, obstacleMask))
        //{
        //    canPlace = false;
        //    transform.position = hit.point;
        //}

        if(Input.GetMouseButtonDown(1))
        {
            i += 90f;
            transform.rotation = Quaternion.Euler(0, i, 0);
        }
        if (Input.GetMouseButton(0) && canPlace == true)
        {
            Instantiate(mainBuilding, transform.position, transform.rotation);
            if (mainBuilding.gameObject.CompareTag("Trees"))
            {
                Vector3 temp;
                temp = this.transform.position;
                temp.y = 0;
                agent.wayPoints.Add(temp);
            }
            Destroy(this.gameObject);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(this.gameObject);
        }
    }
}
