using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float HorizontalMovemetOffset = 1;
    public float VerticalMovemetOffset = 1;

    public Text scoreText;
    public Button startButton;
    private int score = 0;
    public bool isPuased = true;
    private BirdController birdController;
    void Start()
    {
        birdController = FindObjectOfType<BirdController>();
        startButton.onClick.AddListener(() => onStartClick());
    }

    private void onStartClick()
    {
        score = 0;
        updateScoreText();
        birdController.reset();
        isPuased = false;
    }

    void Update()
    {
        startButton.gameObject.SetActive(isPuased);
    }

    public void onTouchedManeOrDeathZone()
    {
        isPuased = true;
    }

    public void onPassedMane()
    {
        score += 1;
        updateScoreText();
    }

    public void updateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
