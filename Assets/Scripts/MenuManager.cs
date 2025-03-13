using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        
    }

    public void ExitTheGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
