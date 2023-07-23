using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Person
{
    [SerializeField] private int hairIndex;
    [SerializeField] private int shirtIndex;
    [SerializeField] private int accessoryIndex;
    [SerializeField] private int eyeIndex;
    [SerializeField] private Speech speech;
    [SerializeField] private int skinIndex;
    [SerializeField] private int hairStyleIndex;

    [SerializeField] bool isGuilty;

    public Person(int hairIndex, int shirtIndex, int accessoryIndex, int eyeIndex, Speech speech, int skinIndex, int hairStyleIndex)
    {
        this.hairIndex = hairIndex;
        this.shirtIndex = shirtIndex;
        this.accessoryIndex = accessoryIndex;
        this.eyeIndex = eyeIndex;
        this.speech = speech;
        this.skinIndex = skinIndex;
        this.hairStyleIndex = hairStyleIndex;
    }

    public int GetHairIndex()
    {
        return hairIndex;
    }

    public int GetShirtIndex()
    {
        return shirtIndex;
    }

    public int GetAccessoryIndex()
    {
        return accessoryIndex;
    }

    public int GetEyeIndex()
    {
        return eyeIndex;
    }

    public Speech GetSpeech()
    {
        return speech;
    }

    public int GetSkinIndex() {return skinIndex; }
    public int GetHairStyleIndex() {return hairStyleIndex;}

    public bool GetGuilty () { return isGuilty; }
    public void SetIsGuilty(bool value) { isGuilty = value; }
}
