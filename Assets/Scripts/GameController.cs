using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float startWait;
    public float spawnWait;
    public float barrierWait;

    public GameObject enemy;
    public GameObject barrier;
    public GameObject coin;

    public Text scoreText;
    public Vector3 spawnValue;

    public int score;
    private Save save;
    private bool newRecord = false;

    private GameObject player;

    void Start()
    {
        save = new Save();

        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();

        player = GameObject.Find("Player");
    }
    
    IEnumerator SpawnWaves()
    {
        Vector3 spawnPosition;
        Vector3 spawnPosition1;
        Vector3 spawnCoin;

        int round = 1;

        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < 5 * round; i++)
            {
                spawnPosition = new Vector3(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y), spawnValue.z);

                Instantiate(enemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(spawnWait);

            for (int i = 0; i < 5 * round; i++)
            {
                spawnPosition = new Vector3(spawnValue.x, Random.Range(6.06f, 14.83f), spawnValue.z);
                spawnPosition1 = new Vector3(spawnValue.x, (spawnPosition.y - 22f), spawnValue.z);
                spawnCoin = new Vector3(spawnValue.x, (spawnPosition.y - 10.6f), spawnValue.z);

                Instantiate(barrier, spawnPosition, Quaternion.identity);
                Instantiate(barrier, spawnPosition1, Quaternion.identity);
                Instantiate(coin, spawnCoin, Quaternion.identity);
                yield return new WaitForSeconds(barrierWait);
            }

            round++;
        }
    }

    void UpdateScore()
    {
        scoreText.text = "" + score;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }
}
