using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        WriteTheScore();
    }

    private void WriteTheScore()
    {
        uiManager.scoreText.text = score.ToString();
    }
}
