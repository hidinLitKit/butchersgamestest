using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance { get; private set; }

    [SerializeField] private AudioSource _source;
    [SerializeField] private SOSFX dataBase;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }
    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;
        _source.PlayOneShot(clip);
    }
    public void PlaySound()
    {
        _source.PlayOneShot(_source.clip);
    }
    public void PlaySound(string name, string id)
    {
        _source.PlayOneShot((id != null && id != "") ? dataBase.GetAudio(name, id) : dataBase.GetAudio(name));
    }

}