//lots is commented out but many scripts used naming conventions from this script, wasn't worth it to make a new one since i'm rushing to meet the deadline :(


using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MaterialEditor : MonoBehaviour
{

    MeshRenderer meshRenderer;
    //public Texture Texture1;
   //public Texture Texture2;
   //public Texture Texture3;

    private string test;

    public Animator PettingAnim;


    ////gets the variable named "mouseObject" from the script "MouseInput" and is updated every frame because the MouseInput script is calling to this script in the Update function
    public void updateMouseInputForMaterialEditor(string mouseObject)
    {
        test = mouseObject;
        //print("the mouse is over: " + test);

       
         ////old method: sets the texture to the OWO picture (and sets it back after the mouse isn't over the "CubeParent"
         // meshRenderer = GetComponent<MeshRenderer>();


        //if the mouse is over or clicking anything but the "BerryParent" animation state will go to Idle (you don't need to tell it to Idle)
        //if (mouseObject != "BerryParent" || mouseObject != "CubeParent")
        {
                ////old method: if the mouse is over or clicking anything but the "BerryParent" object the cubes face texture will be "OWO" 
                // meshRenderer.material.SetTexture("_MainTex", Texture1);

            //PettingAnim.Play("Idle");
        }


        //if the mouse is clicked and over the "CubeParent" object the animation state will go to IsPettingAnimation
        if (mouseObject == "CubeParent")
        {
                ////old method: sets the texture to the UWU if the mouse is clicked and over the "CubeParent" object
                //meshRenderer.material.SetTexture("_MainTex", Texture1);

            PettingAnim.Play("IsPettingAnimation");
        }
    }

   
    //changes the cube's texture to the "OAO" texture when you are "holidng" the berry (clicking and dragging the berry) 
    public void updateDragObjecrForMaterialEditor(bool berryIsPickedUp)
    {

        if (berryIsPickedUp == true)
        {
           // meshRenderer.material.SetTexture("_MainTex", Texture3);

            PettingAnim.Play("MouthOpenAnimation");

        }
    }


        // Start is called before the first frame update
        void Start()
    {
        PettingAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //meshRenderer = GetComponent<MeshRenderer>();
       // meshRenderer.material.SetTexture("_MainTex", albedoTexture1);
    }
}
