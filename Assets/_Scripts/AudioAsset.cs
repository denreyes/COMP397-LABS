using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Audio Asset")]
public class AudioAsset : MonoBehaviour
{
    public string AudioName;
    public AudioClip AudioClip;
    public bool IsLooping = false;
}
