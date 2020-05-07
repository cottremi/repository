using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CubeAnimataionEditor : MonoBehaviour
{


    private string test;

    public Animator CubeAnim;


    ////gets the variable named "mouseObject" from the script "MouseInput" and is updated every frame because the MouseInput script is calling to this script in the Update function
    public void updateMouseInputForMaterialEditor(string mouseObject)
    {
        test = mouseObject;
       

        //if the mouse is clicked and over the "CubeParent" object the animation state will go to IsPettingAnimation
        if (mouseObject == "CubeParent")
        {

            CubeAnim.Play("IsPettingAnimation");
        }
    }


    //changes the cube's texture to the "OAO" texture when you are "holidng" the berry (clicking and dragging the berry) 
    public void updateDragObjecrForMaterialEditor(bool berryIsPickedUp)
    {

        if (berryIsPickedUp == true)
        {
          

            CubeAnim.Play("MouthOpenAnimation");

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        CubeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
