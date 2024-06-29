using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text colorDisplayText;
    public Button[] colorButtons;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public Image[] hearts;
    public int startingHearts = 3;
    private int remainingHearts;
    private int score = 0;
    private float timer = 5f;
    public AudioClip correctAnswerClip;
    public AudioClip loseHeartClip;
    private AudioSource audioSource;

    private string[] colors = { "Black", "Blue", "Brown", "Pink", "DarkGreen", "LightGreen", "Red", "White", "Purple", "Orange", "Cyan", "Yellow" };
    private string currentColor;

    void Start()
    {
        
        remainingHearts = startingHearts;
        SetRandomColor();
        UpdateScore();
        UpdateHearts();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timer).ToString();

        if (timer <= 0f)
        {
            LoseHeart();
            ResetTimer();
            SetRandomColor();
        }
    }

    void SetRandomColor()
    {
        currentColor = colors[Random.Range(0, colors.Length)];
        colorDisplayText.text = currentColor + " Is Impostor";
        colorDisplayText.color = ColorFromName(currentColor);
    }

    Color ColorFromName(string colorName)
    {
        switch (colorName)
        {
            case "Black": return Color.black;
            case "Blue": return Color.blue;
            case "Brown": return new Color(0.65f, 0.16f, 0.16f); //Brown
            case "Pink": return Color.magenta;
            case "DarkGreen": return new Color(0f, 0.5f, 0f); //DarkGreen
            case "LightGreen": return Color.green;
            case "Red": return Color.red;
            case "White": return Color.white;
            case "Purple": return new Color(0.5f, 0f, 0.5f); //Purple
            case "Orange": return new Color(1f, 0.5f, 0f); //Orange
            case "Cyan": return Color.cyan;
            case "Yellow": return Color.yellow;
            default: return Color.black;
        }
    }

    public void OnColorButtonClicked(string colorName)
    {
        if (colorName == currentColor)
        {
            score++;
            UpdateScore();
            PlaySound(correctAnswerClip);

        }
        else
        {
            LoseHeart();
        }

        ResetTimer();
        SetRandomColor();
    }

    void LoseHeart()
    {
        remainingHearts--;
        UpdateHearts();
        PlaySound(loseHeartClip);


        if (remainingHearts <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }
    }

    void ResetTimer()
    {
        timer = 5f;
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < remainingHearts;
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}