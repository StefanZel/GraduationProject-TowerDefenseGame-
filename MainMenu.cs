using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Main";
    public string infoScene = "InfoScene";

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }
    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
    public void Info()
    {
        sceneFader.FadeTo(infoScene);
    
    }
}
