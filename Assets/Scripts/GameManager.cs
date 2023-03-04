using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public GameObject obstacle;
    public Transform spawnPoint;
    public int score = 0;
    public int bestScore;
    public static GameManager instance;
    public bool inGame = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject playButton;
    public GameObject player;
    public GameObject menuButton;
    public GameObject coinsCounter;
    public TextMeshProUGUI coinsCounterText;
    public GameObject shopButton;
    public GameObject FpsText;
    public GameObject obstacle0;
    public GameObject coin0;
    public GameObject obstacle1;
    public GameObject coin1;
    public GameObject obstacle2;
    public GameObject coin2;
    public GameObject obstacle3;
    public GameObject coin3;
    public GameObject obstacle4;
    public GameObject coin4;
    public GameObject obstacle5;
    public GameObject coin5;
    public GameObject obstacle6;
    public GameObject coin6;
    public GameObject obstacle7;
    public GameObject coin7;
    public GameObject obstacle8;
    public GameObject coin8;
    public GameObject obstacle9;
    public GameObject coin9;
    public GameObject obstacle10;
    public GameObject coin10;
    public int coins;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        coinsCounterText.text = coins.ToString();
        bestScoreText.text = $"Best score: {bestScore}";
        scoreText.text = score.ToString();
    }

    public void LoadData(GameData data)
    {
        this.coins = data.coins;
        this.bestScore= data.bestScore;
    }

    public void SaveData(ref GameData data)
    {
        data.coins = this.coins;
        data.bestScore = this.bestScore;
    }

    IEnumerator SpawnObstacles()
    {
        int i = 0;
        while (true)
        {
            Debug.Log(i.ToString());

            float waitTime = Random.Range(0.8f, 1.6f);

            yield return new WaitForSeconds(waitTime);

            if (i == 0)
            {
                obstacle0.GetComponent<Obstacle>().canGo = true;
                coin0.SetActive(true);
            }
            else if (i == 1)
            {
                obstacle1.GetComponent<Obstacle>().canGo = true;
                coin1.SetActive(true);
            }
            else if (i == 2)
            {
                obstacle2.GetComponent<Obstacle>().canGo = true; 
                coin2.SetActive(true);
            }
            else if (i == 3)
            {
                obstacle3.GetComponent<Obstacle>().canGo = true;
                coin3.SetActive(true);
            }
            else if (i == 4)
            {
                obstacle4.GetComponent<Obstacle>().canGo = true;
                coin4.SetActive(true);
            }
            else if (i == 5)
            {
                obstacle5.GetComponent<Obstacle>().canGo = true;
                coin5.SetActive(true);
            }
            else if (i == 6)
            {
                obstacle6.GetComponent<Obstacle>().canGo = true;
                coin6.SetActive(true);
            }
            else if (i == 7)
            {
                obstacle7.GetComponent<Obstacle>().canGo = true;
                coin7.SetActive(true);
            }
            else if (i == 8)
            {
                obstacle8.GetComponent<Obstacle>().canGo = true;
                coin8.SetActive(true);
            }
            else if (i == 9)
            {
                obstacle9.GetComponent<Obstacle>().canGo = true;
                coin9.SetActive(true);
            }
            else if (i == 10)
            {
                obstacle10.GetComponent<Obstacle>().canGo = true;
                coin10.SetActive(true);
            }

            if (i > 9)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }
    }

    //public void ScoreUp()
    //{
    //    score++;
    //    scoreText.text = score.ToString();
    //}

    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);
        menuButton.SetActive(false);
        coinsCounter.SetActive(false);
        bestScoreText.gameObject.SetActive(false);
        shopButton.gameObject.SetActive(false);
        FpsText.gameObject.SetActive(true);
        StartCoroutine("SpawnObstacles");
        inGame = true;
    }

    public void GameEnd()
    {
        //all obstacle to spawn point
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject Obstacle in Obstacles)
        {
            Obstacle.GetComponent<Obstacle>().canGo = false;
            Obstacle.transform.position = spawnPoint.position;
        }

        if (bestScore < score)
        {
            bestScore = score;
            bestScoreText.text = $"Best score: {bestScore}";
        }

        coins += score;
        score = 0;
        scoreText.text = "0";
        player.SetActive(false);
        playButton.SetActive(true);
        menuButton.SetActive(true);
        coinsCounter.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        shopButton.gameObject.SetActive(true);
        FpsText.gameObject.SetActive(false);
        StopCoroutine("SpawnObstacles");
        inGame = false;

        CancelInvoke();
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}