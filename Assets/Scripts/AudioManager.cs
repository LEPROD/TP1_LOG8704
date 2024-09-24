using UnityEngine;
using UnityEngine.Serialization;
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip multipleLaunchesSound;

    [SerializeField]
    private AudioClip singleLaunchSound;


    private void Awake()
    {
        // Pattern singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            // Garde la musique lors de la rotation de caméra
            DontDestroyOnLoad(gameObject);
        }
    }

    public static AudioManager instance { get; private set; }

    public void PlaySingleLaunchSound()
    {
        audioSource.PlayOneShot(singleLaunchSound);
    }

    public void PlayMultipleLaunchesSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(multipleLaunchesSound);

    }
}