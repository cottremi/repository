using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class pettingTimer : MonoBehaviour
{
    
    ////viariables for the timer
    public float currentTime = 0f;
    float startingTime = 1.5f;

    //viarible for the animations on the "cube" object
    public Animator anim;

    private bool affectionPoints = false;


    private StartParticles StartParticlesScript;
    private HappinessDisplay HappinessDisplayScript;

    void Awake()
    {
        StartParticlesScript = GameObject.FindObjectOfType<StartParticles>();
        HappinessDisplayScript = GameObject.FindObjectOfType<HappinessDisplay>();
    }

    ////gets the variable named "mouseObject" from the script "MouseInput" and is updated every frame because the MouseInput script is calling to this script in the Update function
    public void updateMouseInputForpettingTimer (string mouseObject)
    {

        ////if the mouse is clicking and over the "CubeParent" (meaning you are currently "petting" the cube) it will start the timer countdown
        ///if statement is also lookng to see if the mouse has moved to the left of if it has moved down
        if (mouseObject == "CubeParent" && Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse Y") < 0)
        {
            currentTime -= 1 * Time.deltaTime;
           // print("Petting timer: " + currentTime);
        }

        ////if the mouse is not over the cube (meaning you aren't "petting" the cube anymore) it will reset the timer back to the beggining
        if (mouseObject != "CubeParent")
        {
            currentTime = startingTime;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //resets the timer at the start of game
        currentTime = startingTime;

        //gets the aniamtion(s) attached to the "cube" object 
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        StartParticlesScript.updatecurrentTimeforStartParticles(currentTime);
        HappinessDisplayScript.updateaffectionPointsforHappinessDisplay(affectionPoints);

        // if the petting time hits zero (or below zero) it resets the counter and plays an animation showing that the petting timer hit zero
        if (currentTime <= 0)
        {
            //gets the animation called "PettingCompleteAnimation" from the animator controller on the "Cube" object
            anim.Play("PettingCompleteAnimation");
            currentTime = startingTime;
            affectionPoints = true;
        }
        else
        {
            affectionPoints = false;
        }

        


    }
}
