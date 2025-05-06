using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI exitText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestScore(){
        score = 0;
        scoreText.text = $"score: {score}";
    }
    public void AddScore(int amount = 1) {
        score += amount;
        scoreText.text = $"score: {score}";
    }
}
