using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu
    (
    fileName = "New Location", 
    menuName = "New Location", 
    order = 0)
]
public class LocationScriptableObject : ScriptableObject
{
    public string locationName;
    public string locationDesc;

    
    
    public LocationScriptableObject north;
    public LocationScriptableObject south;
    public LocationScriptableObject east;
    public LocationScriptableObject west;
    
    /*
    public string (function name); //if it's null then you do nothing, if its not null it calls the function by calling it with invoke, use public, try private. 
     function turn off one of the directional button, jump in lake button -  takes another scene, 
     button on that scene you back to the lake, Game Manager Singleton- boolean has jumped in lake, false you can jump in lake, true you cant jump in lake, 
     boolean determines whether the button is shown (turn button on or off), nonactive normally but this turns it on (calls it) otherwise it's not active.
     * 
     */
    
    public void PrintLocation()
    {
        string printStr = "\nLocationName" + locationName + 
                          "\nLocation Description" + locationDesc;
        
        Debug.Log(printStr);
    }
        
    public void UpdateCurrentLocation(GameManager gm)
    {
        //if function name is not equal to null, public function
        gm.titleUI.text = locationName;
        gm.descriptionUI.text = locationDesc;
        
        if (north == null)
        {
            gm.buttonNorth.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonNorth.gameObject.SetActive(true);
            north.south = this;
        }
        //if you can only go south, then the woods are initially dirty
        if (north == null && west==null && east==null)
        {
            gm.buttonClean.gameObject.SetActive(true);
            gm.woodsDirty.gameObject.SetActive(true);
        }
        else
        {
            gm.buttonClean.gameObject.SetActive(false);
            gm.woodsDirty.gameObject.SetActive(false);
        }
        
        //if you can only go east, then the beach is initially dirty
        if (north == null && west==null && south==null)
        {
            gm.buttonClean.gameObject.SetActive(true);
            gm.beachDirty.gameObject.SetActive(true);
        }
        else
        {
            gm.beachDirty.gameObject.SetActive(false);
        }
        
        //if you can move any direction, then you are home
        if (north != null && west!=null && south!=null && east != null)
        {
            gm.home.gameObject.SetActive(true);
        }
        else
        {
            gm.home.gameObject.SetActive(false);
        }
        
        //if you can only move south or north, then the bridge is initially dirty

        if (north != null && south != null && east == null && west == null)
        {
            gm.buttonClean.gameObject.SetActive(true);
            gm.bridgeDirty.gameObject.SetActive(true);
        }
        else
        {
            gm.bridgeDirty.gameObject.SetActive(false);
        }
        
        //if you can only move west, then the backyard is initially dirty

        if (west != null && north == null && south == null && east == null)
        {
            gm.buttonClean.gameObject.SetActive(true);
            gm.backyardDirty.gameObject.SetActive(true);
        }
        else
        {
            gm.backyardDirty.gameObject.SetActive(false);
        }
        
        //if you can only move north, the park is initially dirty
        if (north != null && south == null && west == null && east == null)
        {
            gm.buttonClean.gameObject.SetActive(true);
            gm.parkDirty.gameObject.SetActive(true);
        }
        else
        {
            gm.parkDirty.gameObject.SetActive(false);
        }
        
        //setting buttons for back and forth relations
        if (south == null)
        {
            gm.buttonSouth.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonSouth.gameObject.SetActive(true);
            south.north = this;
        }
        
        if (east == null)
        {
            gm.buttonEast.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonEast.gameObject.SetActive(true);
            east.west = this;
        }
        
        if (west == null)
        {
            gm.buttonWest.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonWest.gameObject.SetActive(true);
            west.east = this;
        }
        
        //    /*
        if (gm.isClean == true)
        {
            Debug.Log(gm.isClean);
            
            //if you can only go south, then you can clean that the woods
            if (north == null && west==null && east==null)
            {
                gm.woodsClean.gameObject.SetActive(true);
                gm.woodsDirty.gameObject.SetActive(false);
            }
            else
            {
                gm.woodsClean.gameObject.SetActive(false);
            }
            
            //if you can only go east, then you can clean clean the beach
            if (north == null && west==null && south==null)
            {
                gm.beachClean.gameObject.SetActive(true);
                gm.beachDirty.gameObject.SetActive(false);
            }
            else
            {
                gm.beachClean.gameObject.SetActive(false);
            }
            
            //if you can only move south or north, then you can clean the bridge

            if (north != null && south != null && east == null && west == null)
            {
                gm.bridgeClean.gameObject.SetActive(true);
                gm.bridgeDirty.gameObject.SetActive(false);
            }
            else
            {
                gm.bridgeClean.gameObject.SetActive(false);
            }
            
            //if you can only move west, then you can clean the backyard

            if (west != null && north == null && south == null && east == null)
            {
                gm.backyardClean.gameObject.SetActive(true);
                gm.backyardDirty.gameObject.SetActive(false);
            }
            else
            {
                gm.backyardClean.gameObject.SetActive(false);
            }
        
            //if you can only move north, then you can clean the park
            if (north != null && south == null && west == null && east == null)
            {
                gm.parkClean.gameObject.SetActive(true);
                gm.parkDirty.gameObject.SetActive(false);
            }
            else
            {
                gm.parkClean.gameObject.SetActive(false);
            }
        }
        // */
        
    }
}
