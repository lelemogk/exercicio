using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] TextMeshProUGUI scoreText, finalScoreText, recordText;
    [SerializeField] GameObject gameOverWindow;

    public void UpdateScoreText()
    {
        scoreText.text = GameManager.instance.Score.ToString();
    }

    public void GameOver()
    {
        finalScoreText.text = GameManager.instance.Score.ToString();
        recordText.text = PlayerPrefs.GetInt("Record").ToString();
        gameOverWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}