// TUTORIAL: https://www.youtube.com/watch?time_continue=33&v=0yHBDZHLRbQ&feature=emb_logo (actually he just gives you the script, it's nice)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    //from tutorial 
    private Vector3 mOffset;
    private float mZCoord;

   //sets the "Material Editor" script as variable
    private MaterialEditor materialEditorScript;
    public bool berryIsPickedUp;
    public bool berryIsInMouseCollisonBox;

    
    //variables for the eating countdown timer
    float currentTime = 0f;
    float startingTime = 5f;

    
    //sets the PlayEatingAnimation script as a variable 
    private PlayEatingAnimation PlayEatingAnimationScript;


    //gets the berry's starting position so that when it spawns a new one it will spanw in the place it started on in frame 1
    private Vector3 spawnPos;
    private Quaternion spawnRot;


    private HungerDisplay HungerDisplayScript;
    private bool hasEatenBerry = false;


    //calls to the "Material Editor" and "PlayingEatingAnimation" scripts so it can send variables to them
    //also gives the spawn variables the berryParent's transform values at frame 1 
    void Awake()
    {
        materialEditorScript = GameObject.FindObjectOfType<MaterialEditor>();
        PlayEatingAnimationScript = GameObject.FindObjectOfType<PlayEatingAnimation>();
        HungerDisplayScript = GameObject.FindObjectOfType<HungerDisplay>();


        spawnPos = transform.position;
        spawnRot = transform.rotation;

    }


    void OnMouseDown()
    {

        //sets a boolean that "Material Editor" script can use so it knows when you picked up the berry
        berryIsPickedUp = true;

        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
   

    }

    void OnMouseUp()
    {
        berryIsPickedUp = false;
       
    }


    // from tutorial
    private Vector3 GetMouseAsWorldPoint()
    {

        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    // from tutorial
    void OnMouseDrag()
    { 
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }


    //starts the timer when the (the berry) collider enters the collider on an object with the tag "Destory", berryIsInMouseCollisionBox is set to TRUE for other scripts to use
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            berryIsInMouseCollisonBox = true;
            berryIsPickedUp = false;
           

            currentTime -= 1 * Time.deltaTime;
            print("Berry Timer: " + currentTime);
        } 
    }

    //when (the berry) when its collider exits the collider on an object with the tag "Destory", berryIsInMouseCollisionBox is set to FALSE for other scripts to use
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            berryIsInMouseCollisonBox = false;
        }
    }


    void Start()
    {
        //resets the timer at the start of game
        currentTime = startingTime;

    }


   //sends variable to the "MaterialEditor" and "PlayEatingAnimation" scripts
   //also spawns new berry with spawn values set at frame 1 (see above script) then destroys the current current berry
   //also sets berryIsInMouseCollisionBox for other scripts to use (stops the PlayingEatingAnimation state from continueing to play)
   private void Update()
    {

        

        if (currentTime <= 0)
        {
            berryIsInMouseCollisonBox = false;
            berryIsPickedUp = false;
            hasEatenBerry = true;
            Instantiate(gameObject, spawnPos, spawnRot);
            Destroy(gameObject);
            
        }
        else
        {
            hasEatenBerry = false;
        }

        materialEditorScript.updateDragObjecrForMaterialEditor(berryIsPickedUp);
        PlayEatingAnimationScript.updateDragObjectPlayEatingAnimation(berryIsInMouseCollisonBox);
        HungerDisplayScript.updatehasEatenBerryforHungerDisplay(hasEatenBerry);

    }
}
