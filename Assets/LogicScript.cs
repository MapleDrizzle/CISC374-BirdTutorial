using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject titleScreen;
    public AudioSource point;
    public AudioSource bgMusic;
    private static bool start = false;

    void Start()
    {
         highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0);
         bgMusic.Play();

         if(start) {
            titleScreen.SetActive(false);
         }
         else {
            Time.timeScale = 0f;
         }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {
        if (gameOverScreen.activeSelf == false) {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();

            if (playerScore > PlayerPrefs.GetInt("highScore", 0)) {
                PlayerPrefs.SetInt("highScore", playerScore);
                PlayerPrefs.Save();
                highScoreText.text = "High Score: " + playerScore;
            }
            
            point.Play();
        }
    }
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver(){
        gameOverScreen.SetActive(true);
        bgMusic.Pause();
    }
    public void title(){
        start = true;
        titleScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
