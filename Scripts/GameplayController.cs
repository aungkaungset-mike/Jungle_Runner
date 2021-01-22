using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    private Text scoreText;
    private int score;

    public GameObject scorePanel;

    public Text finalScoreText;
    public Animator final;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        StartCoroutine(CountScore());
    }
 
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.1f);
        score++;
        scoreText.text = score.ToString();

        StartCoroutine(CountScore());
    }
    public void Gameover()
    {
        scorePanel.SetActive(false);
        finalScoreText.text = "Score: " + score;
        final.Play("Final");
    }
    public void Again()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
