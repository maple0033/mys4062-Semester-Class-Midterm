
using UnityEngine;

public class NextPageButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnButtonClick() //this lets us check for button click
    {
        Debug.Log("Button clicked");
        Debug.Log("Instance is null: " + (LevelManager.Instance == null));
        Debug.Log("Current level: " + LevelManager.Instance.CurrentLevel);
        LevelManager.Instance.GoToNextLevel();
    }
}
