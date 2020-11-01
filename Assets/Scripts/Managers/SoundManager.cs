using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip breakSFX, cutSFX;

    float waitBreakTime = 1f;
    float waitCutTime = 0.1f;
    bool waitCutSound;

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayBreakSound()
    {
        myAudioSource.PlayOneShot(breakSFX);
        StartCoroutine(StopBreakSound());
    }

    IEnumerator StopBreakSound()
    {
        yield return new WaitForSeconds(waitBreakTime);
        myAudioSource.Stop();
    }

    public void PlayCutSound()
    {
        if (!waitCutSound)
        {
            myAudioSource.PlayOneShot(cutSFX);
            waitCutSound = true;
            StartCoroutine(WaitCutCorn());
        }
    }

    IEnumerator WaitCutCorn()
    {
        yield return new WaitForSeconds(waitCutTime);
        waitCutSound = false;
    }
}
