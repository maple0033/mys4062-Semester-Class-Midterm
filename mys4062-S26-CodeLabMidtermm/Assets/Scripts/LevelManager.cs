using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    private int currentLevel = 0;

    public int CurrentLevel //property time
    {
        get 
        { return currentLevel; }
        set
        {
            currentLevel = value;
            Debug.Log(currentLevel);
            SceneManager.LoadScene(currentLevel);
        }
    }
  
    void Awake()
    { //singleton timeeeeee
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public void GoToNextLevel() //made public so that we can click click
    {//lets you access this function from other scripts
        CurrentLevel++;
    }
}
