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

    [SerializeField] private Sprite[] lifeSprites;

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

    public void UpdateLive(int live)
    {
        
    }


    public void UpdateScore(int score)
    {

    }

    public void UpdateHighScore()
    {

    }

    public void UpdateCoin() 
    {

    }

    public void UpdateWave() 
    {
    }
}
