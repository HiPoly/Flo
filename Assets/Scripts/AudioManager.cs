using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip jump;
    public AudioClip grab;
    public AudioClip upgrade;
    public AudioClip _lock;
    public AudioClip _unlock;
    public AudioClip zap;
    public AudioClip impact;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
