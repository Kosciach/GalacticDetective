using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [Header("====Data====")]
    [SerializeField] int _score;
    [SerializeField] int _lives;
    [SerializeField] int _highScore;

    [Header("====TextsUI====")]
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _highScoreText;
    [SerializeField] TextMeshProUGUI _livesText;

    private string _highScoreKey;
    private void Start()
    {
        _highScoreKey = "HighScore";
        if (!PlayerPrefs.HasKey(_highScoreKey))
        {
            PlayerPrefs.SetInt(_highScoreKey, 0);
        }
        else
        {
            _highScore = PlayerPrefs.GetInt(_highScoreKey);
            _highScoreText.text = "HighScore: " + _highScore.ToString();
        }
    }
    public void TakeLife()
    {
        if (_lives > 0)
        {
            _lives--;
            _livesText.text = "Lives: "+_lives.ToString();
        }
        else Die();
    }

    public void AddScore()
    {
        Debug.Log(PlayerPrefs.GetInt(_highScoreKey));
        _score++;
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt(_highScoreKey, _highScore);
            _highScoreText.text = "HighScore: " + _highScore.ToString();
        }
        _scoreText.text = "Score: "+_score.ToString();
    }

    private void Die()
    {
        Debug.Log("Ksacu jeœli to czytasz to umiesz czytaæ - Pozdro600");
    }
}
