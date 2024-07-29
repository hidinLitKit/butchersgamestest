using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFXDataBase", menuName = "ScriptableObjects/Audio/SFXAsset")]
public class SOSFX : ScriptableObject
{
    [SerializeField] private List<SoundData> databases;
    [SerializeField] private AudioClip _placeholder;

    public AudioClip GetAudio(string dbname, string id)
    {
        if (id == null || id == "") return GetAudio(dbname);
        SoundData datab = databases.Find(db => db.databaseName == dbname);
        AudioClip cl = datab.audios.Find(aud => aud.id == id).clip;
        return (cl != null) ? cl : datab.defaultClip;
    }
    public AudioClip GetAudio(string dbname)
    {
        AudioClip cl = databases.Find(db => db.databaseName == dbname).defaultClip;
        return (cl != null) ? cl : _placeholder;
    }
    public AudioClip GetRandomAudio(string dbname)
    {
        SoundData datab = databases.Find(db => db.databaseName == dbname);
        AudioClip cl = datab.audios[Random.Range(0, datab.audios.Count)].clip;
        return cl;
    }
}

[System.Serializable]
public class SoundData
{
    public string databaseName;
    public AudioClip defaultClip;
    public List<AudioDataBase> audios;
    //public List<Monologue> monologues;

    [System.Serializable]
    public class AudioDataBase
    {
        public string id;
        public AudioClip clip;
    }
}
