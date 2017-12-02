using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {

    public GameObject[] waypoints;
    public int waypointNum = 0;
    public bool isGameOver;
    

    public float minDist = 0.01f;   // minimum distance between bird and waypoint before waypoint is "reached"
    public float speed = 0.0f;      // speed of bird
    //public float accel = 0.2f;    not being used currently
    public float topSpeed = 15.0f;  // top speed of bird
    //public float runNum = 0.0f;   not being used currently
    

    public bool rand = false;       // if true sets path to random, if false follows sequentially 
    public bool go = true;          // sets the bird on its path

	
	void Start () {

        
    }
	
	
	void Update () {
        float distance = Vector3.Distance(gameObject.transform.position, waypoints[waypointNum].transform.position);
        
        if (go && isGameOver == false)
        {
            if (distance > minDist)
            {
                Move(); 
            }
            else
            {
                if (!rand)
                {
                    if(waypointNum + 1 == waypoints.Length)
                    {
                        waypointNum = 0;
                    }
                    else
                    {
                        waypointNum++;   
                    }
                }
                else
                {
                    waypointNum = Random.Range(0, waypoints.Length);
                }
            }
        }
	}
    public void Move()
    {
        gameObject.transform.LookAt(waypoints[waypointNum].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        if(speed >= topSpeed)
        {
            speed = topSpeed;       //limits top speed of bird
        }
    }
}
