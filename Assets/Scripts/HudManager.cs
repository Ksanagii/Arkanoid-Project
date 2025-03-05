using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] GameObject gameOverScreen;
    Animator gameOverAnim;

    void Start()
    {
        gameOverAnim = gameOverScreen.GetComponent<Animator>();
        
    }

    void Update()
    {
        if(!PlayerMove.death)
        {
            pointsText.text = "points: " + BallMove.points;
        }
        else
        {
            Destroy(pointsText);
            gameOverAnim.SetTrigger("Morreu");
        }

    }

}
