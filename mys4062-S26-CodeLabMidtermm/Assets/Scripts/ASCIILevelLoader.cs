using UnityEngine;
using System.IO;

public class ASCIILevelLoader : MonoBehaviour
{
    public GameObject blueSquare;
    public GameObject greenSquare;
    
    public string fileLocation;
    private string fullPath;  
    GameObject loadedLevel;
    
    public int xOffset = 5;
    public int yOffset = 10;
    
    void Start()
    {
        //creating the full path to the file location 
        fullPath = Application.dataPath + "/" + fileLocation;
        
        //pulls information from the file to create a new file in editor based on file contents
        LoadPage();
    }
//TODO: set up the page drawing so we know what to copy, based on ASCII file
    // Update is called once per frame
    void LoadPage()
    {
        xOffset = 0;
        yOffset = 0;
        Debug.Log(this.fullPath);
        loadedLevel = new GameObject("Level" + LevelManager.Instance.CurrentLevel);
        
        string fullPath = this.fullPath.Replace("<num>", LevelManager.Instance.CurrentLevel + "");
        string[] lines = File.ReadAllLines(fullPath);
        
        //TODO: Fix the offsets! the cubes are spawning in weird locations
        foreach (string line in lines)
        {
            int lengthOfLine = (line.Length / 2) + 4;
            if (lengthOfLine > xOffset) //if the offset of the line is greater than current offset, replace current offset with this one
            {
                xOffset = lengthOfLine;
            }
        }
        yOffset = lines.Length / 2 + 2; //offset y based on how many linse there are in the file
        
        
//TODO: check the ascii files for whats being used 
        for (int y = 0; y < lines.Length; y++)
        {
            string currentLineFromFile = lines[y];
            for (int x = 0; x < currentLineFromFile.Length; x++)
            {
                char currentChar = currentLineFromFile[x];
                GameObject newObject = null;
                if (currentChar == 'B')
                {
                    newObject = Instantiate<GameObject>(blueSquare);
                }

                if (currentChar == 'G')
                {
                    newObject = Instantiate<GameObject>(greenSquare);
                }

                if (newObject != null)
                {
                    newObject.transform.position = new Vector2(x - xOffset, -y + yOffset);
                    newObject.transform.SetParent(loadedLevel.transform); //parent object to loadedlevel so it destroys when loadedlevel changes
                }
                
            }
            
        }
            
    }
}
