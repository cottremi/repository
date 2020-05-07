//// ADAPTED FROM TUTORIAL: https://www.youtube.com/watch?v=EANtTI6BCxk 

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.VersionControl;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private string objectBeingPet = "none";

   ////sets other scripts as variables
    private MaterialEditor materialEditorScript;
    private pettingTimer pettingTimerScript;

    ////gets the other scripts
    void Awake()
    {
        pettingTimerScript = GameObject.FindObjectOfType<pettingTimer>();
        materialEditorScript = GameObject.FindObjectOfType<MaterialEditor> ();
        
    }

    void Start()
    {
       
    }
    
    void Update()
    {

        ////sends variable to the other scripts
        materialEditorScript.updateMouseInputForMaterialEditor(objectBeingPet);
        pettingTimerScript.updateMouseInputForpettingTimer(objectBeingPet);

       
        ////sends information on whaat the mouse is oever when the left click is down
        if (Input.GetMouseButton(0)) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform != null)
                {
                    ////sets the object being hit as a string variable so it can be acessed in other scripts
                    //PrintName(hit.transform.gameObject);
                    objectBeingPet = (hit.transform.gameObject.name);
                    print(objectBeingPet);
                    
              
                } 
            }
	    }

       //// when you let up the left mouse button the string changes to none so the program knows you let go of the mouse and doesn't stay on the last vairable forever
        if (Input.GetMouseButtonUp(0))
        {
            objectBeingPet = "none";
            print(objectBeingPet);
        }
    }

    private void PrintName(GameObject go)
    {
        //print(go.name);
    }
}
