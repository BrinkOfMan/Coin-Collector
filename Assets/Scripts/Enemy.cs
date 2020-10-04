using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private bool dangerboi;
    [SerializeField]
    private Transform[] waypoints;
    private Vector3 targetPosition;
    [SerializeField]
    [Range(0.5f,5.0f)]
    private float moveSpeed = 1;
    private int waypointsIndex;

    void Start()
    {
        Application.targetFrameRate = 144;
        targetPosition = waypoints[0].position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, .128f * moveSpeed);

        if(!dangerboi)
        {
            if(Vector3.Distance(transform.position, targetPosition) <= 0.1f)
            {
                if (waypointsIndex >= waypoints.Length-1)
                {
                    waypointsIndex = 0;
                }
                else
                {
                waypointsIndex++;
                }
                targetPosition = waypoints[waypointsIndex].position;
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, targetPosition) <= 20.5f)
            {
                if(Vector3.Distance(transform.position, targetPosition) <= 0.1f)
                {
                    if (waypointsIndex >= waypoints.Length-1)
                    {
                        waypointsIndex = 0;
                    }
                    else
                    {
                    waypointsIndex++;
                    }
                    targetPosition = waypoints[waypointsIndex].position;
                }
                else
                {
                    targetPosition = waypoints[waypointsIndex].position;
                }
                
            }
        }
        
    }
}
