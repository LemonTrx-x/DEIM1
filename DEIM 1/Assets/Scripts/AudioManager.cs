using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioClip[] backgroundMusic;
    [SerializeField] AudioClip[] soundEffects;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource effectsSource;

    const float musicVolume = 0.4f;
    const float effectsVolume = 0.3f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        CreateAudioSourcesIfNeeded();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CreateAudioSourcesIfNeeded();
        PlayMusic(0);
    }

    private void Start()
    {
        PlayMusic(0);
    }

    void CreateAudioSourcesIfNeeded()
    {
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
        }

        if (effectsSource == null)
        {
            effectsSource = gameObject.AddComponent<AudioSource>();
        }

        musicSource.volume = musicVolume;
        effectsSource.volume = effectsVolume;
    }

    public void PlayMusic(int index)
    {
        if (musicSource == null || backgroundMusic == null || index < 0 || index >= backgroundMusic.Length || backgroundMusic[index] == null)
        {
            return;
        }

        musicSource.volume = musicVolume;
        musicSource.clip = backgroundMusic[index];
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySound(int index)
    {
        if (effectsSource == null || soundEffects == null || index < 0 || index >= soundEffects.Length || soundEffects[index] == null)
        {
            return;
        }

        effectsSource.volume = effectsVolume;
        effectsSource.PlayOneShot(soundEffects[index]);
    }
}
