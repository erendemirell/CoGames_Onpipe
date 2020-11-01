using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject confettiFXLeft;
    [SerializeField] GameObject confettiFXRight;

    bool isGameFinished;

    Player player;
    CameraFollow cameraFollow;
    UIManager uiManager;
    GameManager gameManager;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        uiManager = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if ((player.transform.position.y >= transform.position.y) && !isGameFinished)
            {
                isGameFinished = true;
                cameraFollow.enabled = false;
                confettiFXLeft.SetActive(true);
                confettiFXRight.SetActive(true);
                uiManager.finishPanel.SetActive(true);
                uiManager.finalScoreText.text = gameManager.score.ToString();
                player.moveSpeed = 30;
            }
        }
    }
}
