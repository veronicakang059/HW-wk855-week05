using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] goals;
    void Start()
    {
        goals = GameObject.FindGameObjectsWithTag("goal");
    }

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D other)
    {
        //GameManager.Instance.GetComponent<ACSIIlevelLoader>().CURRENTLEVEL++;
        Destroy(gameObject);
        //print(goals);
        if (goals == null || goals.Length==0)

    {
            //GameManager.Instance.GetComponent<ACSIIlevelLoader>().CURRENTLEVEL++;
            SceneManager.LoadScene(1);
    }
        
    }
}
