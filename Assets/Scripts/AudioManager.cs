using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip StartSound;
    [SerializeField]
    AudioClip KickSound;
    [SerializeField]
    AudioClip HitSound;
    [SerializeField]
    AudioClip WinSound;
    [SerializeField]
    AudioClip ChewSound;
    [SerializeField]
    AudioClip DanceSound;

    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void PlayStartSound()
    {
        audioSource.PlayOneShot(StartSound, 1f);
    }

    public void PlayKickSound()
    {
        audioSource.PlayOneShot(KickSound, 1f);
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(HitSound, 1f);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(WinSound, 1f);
    }

    public void PlayChewSound()
    {
        audioSource.PlayOneShot(ChewSound, 1f);
    }

    public void PlayDanceSound()
    {
        audioSource.PlayOneShot(DanceSound, 1f);
    }

}
