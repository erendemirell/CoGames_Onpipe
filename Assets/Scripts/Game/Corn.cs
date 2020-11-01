using UnityEngine;

public class Corn : MonoBehaviour
{
    [SerializeField] float force;

    Rigidbody rigidbody;

    GameManager gameManager;
    SoundManager soundManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            soundManager.PlayCutSound();
            rigidbody.isKinematic = false;
            rigidbody.AddForce(-transform.up * force);
            rigidbody.AddTorque(-transform.forward * force);
            gameManager.score++;
            Destroy(gameObject, 3f);
        }
    }
}
