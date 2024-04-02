using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI titleUI;
    public TextMeshProUGUI descriptionUI;

    public LocationScriptableObject currentLocation;

    public Button buttonNorth;
    public Button buttonSouth;
    public Button buttonEast;
    public Button buttonWest;

    public Button buttonClean;

    public GameObject beachDirty;
    public GameObject beachClean;

    public GameObject woodsDirty;
    public GameObject woodsClean;

    public GameObject home;

    public GameObject bridgeDirty;
    public GameObject bridgeClean;

    public GameObject parkDirty;
    public GameObject parkClean;

    public GameObject backyardDirty;
    public GameObject backyardClean;

    public bool isClean = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLocation.PrintLocation();
        currentLocation.UpdateCurrentLocation(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveDir(string dirChar)
    {
        switch (dirChar)
        {
            case "N":
                currentLocation = currentLocation.north;
                break;
            
            case "S":
                currentLocation = currentLocation.south;
                break;
            
            case "E":
                currentLocation = currentLocation.east;
                break;
            
            case "W":
                currentLocation = currentLocation.west;
                break;
            case "C":
                isClean = true;
                Debug.Log("is this happening?");
                break;
            default:
                Debug.Log("WTF? That's valid?");
                break;
        }
        currentLocation.UpdateCurrentLocation(this);
        
        //Function Activate Lake - invoke - make a boolean turn on lake, in one location set it to true, every other location set it to false, at the top set it to false, one location set it to true.
        
    }
    
}
