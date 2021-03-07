using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Transform camTarget;
    
    void Start()
    {
        if (!camTarget)
        {
            camTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(camTarget.transform.position.x,camTarget.transform.position.y,0);
    }

 
}
