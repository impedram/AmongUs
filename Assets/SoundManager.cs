using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip mainSoundtrack;
    private AudioSource audioSource;

    void Awake()
    {
        if (FindObjectsOfType<SoundManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mainSoundtrack;
        audioSource.loop = true;
    }

    void Start()
    {
        PlayMainSoundtrack();
    }

    public void PlayMainSoundtrack()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMainSoundtrack()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    void OnSceneUnloaded(Scene current)
    {
        StopMainSoundtrack();
    }
}
