using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHolder : MonoBehaviour
{
    [Header("Menu Sounds")]
    [SerializeField]
    AudioSource[] buttonSounds;

    [Header("Gameplay Sounds")]
    [SerializeField] AudioSource[] gameplaySounds;

    public AudioSource[] GetButtonSounds() { return buttonSounds; }
    public AudioSource[] GetGameplaySounds() {  return gameplaySounds; }
}
