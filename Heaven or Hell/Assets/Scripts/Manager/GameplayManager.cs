using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    #region Singleton
    public static GameplayManager Instance;

    public GameplayManager()
    {
        if (Instance != this)
        {
            Instance = this;
        }
    }
    #endregion

    private int roundsAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
