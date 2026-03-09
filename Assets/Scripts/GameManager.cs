using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;

    private float spawnRate = 1.0f;

    public bool isGameActive;

    public Button restartButton;

    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
       isGameActive = true;
    }


    // Update is called once per frame
  IEnumerator SpawnTarget()
  {
    while (isGameActive) {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]);
    }
  }

  public void GameOver()
  {
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
  }

  public void UpdateScore(int scoreToAdd)
  {
    score += scoreToAdd;
   scoreText.text = "Score: " + score;

   if (score < 0)
   {
    GameOver();
   }
  }

  public void RestartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void StartGame()
  {
    isGameActive = true;
    score = 0;
    StartCoroutine(SpawnTarget());
    UpdateScore(0);
    titleScreen.gameObject.SetActive(false);
  }
}
