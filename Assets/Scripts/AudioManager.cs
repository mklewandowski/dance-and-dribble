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
    [SerializeField]
    AudioClip CurseSound;
    [SerializeField]
    AudioClip ScreamSound;
    [SerializeField]
    AudioClip TechSound;

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

    public void PlayCurseSound()
    {
        audioSource.PlayOneShot(CurseSound, 1f);
    }

    public void PlayTechSound()
    {
        audioSource.PlayOneShot(TechSound, 1f);
    }

    public void PlayScreamSound()
    {
        audioSource.PlayOneShot(ScreamSound, 1f);
    }

}
