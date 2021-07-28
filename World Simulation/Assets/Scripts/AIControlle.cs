using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIControlle : MonoBehaviour
{
    public List<Vector3> wayPoints;
    NavMeshAgent agent;
    int currentway=0;
    public bool traveling = true;
    bool waiting;
    float waitTime = 0;
    [SerializeField] float totalWaitTime = 4;
 //   [SerializeField] GameObject startingPoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      
    }
    private void FixedUpdate()
    {
  
        patrol();
        
    }
    // Update is called once per frame
    
    public void patrol()
    {
       
        //if (traveling == true && agent.stoppingDistance <= 2f)
        //{
        //    Debug.Log("working");   
        //    traveling = false;
        //    waiting = true;
        //    waitTime = 0;
        //    if(waiting)
        //    {
        //        waitTime += Time.deltaTime;
        //        if(waitTime>= totalWaitTime)
        //        {
        //            waiting = false;
        //            changewayPoint();
        //            setDestination();
        //        }
        //    }
        //}
        if(traveling== true)
        {
            if(wayPoints.Count==1)
            {
                setDestination();
            }
           else if(wayPoints.Count>1)
            {
                changewayPoint();
                setDestination();
            }
        }
        
    }
    public void setDestination()
    {
        if(wayPoints != null)
        {
            Vector3 target = wayPoints[currentway];
            agent.SetDestination(target);
            traveling = true;
            Debug.Log("working");
        }
       
    }

    public void changewayPoint()
    {
        currentway = (currentway + 1) % wayPoints.Count;
    }
}
