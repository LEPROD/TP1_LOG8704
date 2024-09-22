using UnityEngine;
using UnityEngine.Serialization;
public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField]
    private AudioSource _audioSource;
    
    [SerializeField]
    private AudioClip multipleLaunchesSound;
    
    [SerializeField]
    private AudioClip singleLaunchSound;

    public static AudioManager Instance
    {
        get
        {
            return _instance;
        }
    }
    
    public void PlaySingleLaunchSound()
    {
        _audioSource.PlayOneShot(singleLaunchSound);
    }
    
    public void PlayMultipleLaunchesSound()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        _audioSource.PlayOneShot(multipleLaunchesSound);

    }
}