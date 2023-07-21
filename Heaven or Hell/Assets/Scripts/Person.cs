using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    [SerializeField] private int hairIndex;
    [SerializeField] private int shirtIndex;
    [SerializeField] private int accessoryIndex;
    [SerializeField] private int eyeIndex;
    [SerializeField] private Speech speech;

    public Person(int hairIndex, int shirtIndex, int accessoryIndex, int eyeIndex, Speech speech)
    {
        this.hairIndex = hairIndex;
        this.shirtIndex = shirtIndex;
        this.accessoryIndex = accessoryIndex;
        this.eyeIndex = eyeIndex;
        this.speech = speech;
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

}
