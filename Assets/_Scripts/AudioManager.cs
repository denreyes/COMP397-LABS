using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _playerSubject;
    [SerializeField] private List<AudioAsset> audios =
        new List<AudioAsset>();
    [SerializeField] private string _musicName;

    void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerSubject =
                player.GetComponent<Subject>();
        }
    }

    void Start()
    {
        var musicAsset = audios.Find(a => a.AudioName == _musicName);
        AudioController.Instance.PlayMusic(musicAsset);
    }

    void OnEnable()
    {
        if(_playerSubject == null)
        {
            return;
        }
        _playerSubject.AddObserver(this);
    }

    void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }

    
    public void OnNotify(PlayerEnums playerEnums)
    {
        AudioAsset asset = null;
        switch (playerEnums)
        {
            case PlayerEnums.Jump:
                asset =
                        audios.Find(s => s.AudioName == "Jump");
                AudioController.Instance.PlaySFX(asset);
                break;
            case PlayerEnums.Died:
                asset =
                        audios.Find(s => s.AudioName == "Die");
                AudioController.Instance.PlaySFX(asset);
                break;
            default:
                break;
        }
    }

}