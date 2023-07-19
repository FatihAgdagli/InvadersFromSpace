using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;

    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;

    [SerializeField] private TextMeshProUGUI cointText;
    private int coint;

    [SerializeField] private TextMeshProUGUI waveText;
    private int wave;

    [SerializeField] private Image[] lifeSprites;

    [SerializeField] private Image healthBar;

    [SerializeField] private Sprite[] healthBars;

    private Color activeColor = new Color(1, 1, 1, 1);

    private Color pasiveColor = new Color(1, 1, 1, 0.25f);


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    public void UpdateLives(int live)
    {
        foreach (Image life in lifeSprites)
        {
            life.color = pasiveColor;
        }

        for (int i = 0; i < live; i++)
        {
            lifeSprites[i].color = activeColor;
        }
    }


    public void UpdateScore(int score)
    {
        this.score += score;

        scoreText.text = this.score.ToString("000,000");
    }

    public void UpdateHealtBar(int healt)
    {
        healthBar.sprite = healthBars[healt];
    }

    public void UpdateHighScore()
    {

    }

    public void UpdateCoin() 
    {

    }

    public void UpdateWave() 
    {
        this.wave ++;

        waveText.text = wave.ToString();
    }
}
