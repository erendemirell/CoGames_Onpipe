using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject breakParticlePrefab;
    [SerializeField] float scaleSpeed = 2f;
    public float moveSpeed = 5f;

    public bool isDead = false;
    bool touched;
    Vector3 startScale;

    PlayerController playerController;
    CameraShake cameraShake;
    SoundManager soundManager;
    UIManager uiManager;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        cameraShake = FindObjectOfType<CameraShake>();
        soundManager = FindObjectOfType<SoundManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void Update()
    {
        TouchControl();
    }

    private void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            touched = true;
        }
        else
        {
            touched = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
        ChangeScale();
    }

    private void ChangeScale()
    {
        if (Input.GetMouseButton(0))
        {
            if (!playerController.isCollidedCylinder)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(0, transform.localScale.y, 0), scaleSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
        }
    }

    private void Move()
    {
        transform.position += Vector3.up * moveSpeed * Time.fixedDeltaTime;
    }

    public void Dead()
    {
        isDead = true;
        soundManager.PlayBreakSound();
        cameraShake.enabled = true;
        cameraShake.shakeDuration = 0.5f;
        uiManager.gameOverPanel.SetActive(true);
        Destroy(gameObject);
        Instantiate(breakParticlePrefab, transform.position, Quaternion.identity);
    }
}
