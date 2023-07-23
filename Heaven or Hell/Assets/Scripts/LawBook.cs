using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LawBook : MonoBehaviour
{
    [SerializeField] private GameObject lawbookLinePrefab;
    [SerializeField] private GameObject parentGameObject;

    private void Awake()
    {
        LawManager.OnSetSentence += AddLineToBook;
    }

    private void OnDestroy()
    {
        LawManager.OnSetSentence -= AddLineToBook;
    }

    public void AddLineToBook(string sentence)
    {
        var bookLineClone = Instantiate(lawbookLinePrefab,parentGameObject.transform);

        TMP_Text text = bookLineClone.GetComponent<TMP_Text>();
        text.SetText(sentence);
    }
    
}
