using System;
using System.IO;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 currentMousePosition;
    
    string  filePath = "/Resources/DraggableObjectLocations/";
    string fileFullPath;
    void Start()
    {
        filePath = Application.dataPath + filePath; //set filepath 
        fileFullPath = filePath + name + ".json";
        
        if (File.Exists(fileFullPath))
        {
            string fileContents = File.ReadAllText(filePath + name + ".json"); //lets put the saved data in a string
            

            Vector3 savePosition = JsonUtility.FromJson<Vector3>(fileContents); //turn it back into a vector 3 for us
            transform.position = savePosition; //set position to that
        }
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition();
    }

    Vector3 GetMousePosition() //this function lets you check if the mouse drags 
    {
        currentMousePosition =  Input.mousePosition;
        currentMousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
       //getting access to the mouse position no matter the Z (do we really need this for 2D tho?)

        currentMousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        //this is gonna take the position on the screen and put it back to the world

        return currentMousePosition; 
    }
    
    void OnMouseUp() //this will save the cube location whenevre you release your mouse
    //this will follow ebtween scenes,not just play throughs
    {
        string jsonPosition = JsonUtility.ToJson(transform.position, true);
        File.WriteAllText(fileFullPath, jsonPosition);
    }
    
    void onDisable()
    {//this lets it save between play throughs
        string jsonPosition = JsonUtility.ToJson(transform.position, true); //this will not pretty print, cheaper
        Debug.Log("Saving position: " + jsonPosition);
        File.WriteAllText(filePath + name + ".json", jsonPosition); 
    }
}
