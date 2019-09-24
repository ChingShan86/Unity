using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public Text highScore;
    public static bool isDead = false;
    public int highscore;

    private void Start()
    {
        highscore = int.Parse(highScore.text.Trim().Split(':')[1]);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isDead = true;
            UpdateHighScore();
            UIManager.OpenRestartMenu();
        }
    }

    void UpdateHighScore()
    {
        int score = PlatformManager.layer;
        if (score > highscore)
        {
            highscore = score;
            highScore.text = "HighScore :" + highscore;
        }
    }

}
