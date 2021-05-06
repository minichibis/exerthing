using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelper : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject start;

    void Update()
    {
        
    }

    public void startTutorial()
    {
        Debug.Log("Start Tutorial");
        //deactivate start
        tutorial.SetActive(true);
        //show tutorial start
        start.SetActive(false);
    }

    public void backToStart()
    {
        Debug.Log("Back to Start");
        //deactivate tutorial
        tutorial.SetActive(false);
        //show start
        start.SetActive(true);
    }
}