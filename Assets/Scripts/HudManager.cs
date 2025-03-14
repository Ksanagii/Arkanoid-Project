using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject victoryScreen;
    Animator gameOverAnim;
    [SerializeField] int victoryPointsRequired;

    void Start()
    {
        gameOverAnim = gameOverScreen.GetComponent<Animator>();
        victoryScreen.SetActive(false);
    }

    void Update()
    {
        if(!PlayerMove.death)
        {
            pointsText.text = "points: " + BallMove.points;
            if(BallMove.points >= victoryPointsRequired)
            {
                victoryScreen.SetActive(true);
                Time.timeScale = 0;

            }
        }
        else
        {
            Destroy(pointsText);
            gameOverAnim.SetTrigger("Morreu");
        }
    }
    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        
    }

    public void ExitTheGame()
    {
        Application.Quit();
        Debug.Log("Exited");
    }

}
