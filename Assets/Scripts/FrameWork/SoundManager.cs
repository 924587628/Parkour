using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get { return _instance; }
    }

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        _instance = this;
    }

    public void PlayAudioByNmae(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    public void PlayMusicByName(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        audioSource.clip = clip;
        audioSource.Play();
    }
}
