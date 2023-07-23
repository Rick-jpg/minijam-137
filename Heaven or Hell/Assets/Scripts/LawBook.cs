using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LawBook : MonoBehaviour
{
    [SerializeField] private GameObject lawbookLinePrefab;
    [SerializeField] private GameObject parentGameObject;

    private void OnEnable()
    {
        LawManager.OnSetSentence += AddLineToBook;
    }

    private void OnDisable()
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
