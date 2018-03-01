using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject GameOverUI;
    public GameObject Main;

    public Text scoreText;

    private Player player;
    private bool paused = false;
    private Camera cam;
    private GameController gc;
    private Save save;

    void Start()
    {
        GameOverUI.SetActive(false);
        PauseUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();

        save = new Save();
    }

    void Update()
    {
        if (!player.isDead)
        {
            if (paused)
            {
                Main.SetActive(false);
                PauseUI.SetActive(true);
                Time.timeScale = 0;
            }

            if (!paused)
            {
                Main.SetActive(true);
                PauseUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else
        {
            scoreText.text = "Score: " + gc.score;

            if(gc.score > save.HighScore())
                save.SaveScore(gc.score);

            cam.transform.localPosition = new Vector2(cam.transform.position.x, 0f);
            GameOverUI.SetActive(true);
            Main.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Pause()
    {
        cam.transform.localPosition = new Vector2(cam.transform.position.x, 0f);
        paused = true;
    }

    public void Resume()
    {
        paused = false;
        cam.transform.localPosition = new Vector2(cam.transform.position.x, 0f);
    }

    public void Restart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);            

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
}
