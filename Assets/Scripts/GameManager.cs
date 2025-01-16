using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // This script updates the score
    // It is  attached to the Game Manager gameobject

    public TextMeshProUGUI scoreText;

    // Score displayed on the canvas
    private int score;
    
    // Text Animation
    private Color increaseColor = Color.green;
    private Color decreaseColor = Color.red;
    private float animationDuration = 0.3f;
    private float targetFontSize = 40f;
    private float originalFontSize;
    private Color originalColor;

    // Sound for missed note
    private AudioSource failAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        failAudioSource = GetComponent<AudioSource>();

        // Initiate score
        score = 0;
        UpdateScore(0);
        originalFontSize = scoreText.fontSize;
        originalColor = scoreText.color;
    }

    // This method is called each time a note is hit or missed
    public void UpdateScore(int scoreToAdd)
    {
        // if a note is hit, the score is +3
        // if a note is missed, -1 and a fail sound is played
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        if (scoreToAdd < 0)
        {
            failAudioSource.Play();
            IsScoreIncreasing(false);
        }
        else
        {
            IsScoreIncreasing(true);
        }
    }

    public void IsScoreIncreasing(bool isIncrease)
    {
        // Assigning the animation color
        Color targetColor = isIncrease ? increaseColor : decreaseColor;
        StartCoroutine(AnimateTextEffect(targetColor));
    }

    private IEnumerator AnimateTextEffect(Color targetColor)
    {
        // The text will increase in size and turn red or green 

        float elapsedTime = 0f;
        float startFontSize = scoreText.fontSize;
        Color startColor = scoreText.color;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationDuration;

            // Interpolate font size and color
            scoreText.fontSize = Mathf.Lerp(startFontSize, targetFontSize, t);
            scoreText.color = Color.Lerp(startColor, targetColor, t);

            yield return null;
        }

        // Revert back to original size and color
        scoreText.fontSize = originalFontSize;
        scoreText.color = originalColor;
    }
}