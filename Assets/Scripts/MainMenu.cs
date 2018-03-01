using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScore;

    private Save save;

    void Start()
    {
        save = new Save();

        highScore.text = "High Score: " + save.HighScore();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Loading");
    }
}
