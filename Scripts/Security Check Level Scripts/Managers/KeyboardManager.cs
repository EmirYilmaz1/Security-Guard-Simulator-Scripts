using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<IDText>().OnEnteredIDTrue += CloseKeyboard;
        FindObjectOfType<DecisionManager>().OnButtonPressed +=  OpenKeyboard;     
    }

    public void CloseKeyboard()
    {
        foreach(Transform key in gameObject.transform)
        {
            key.gameObject.SetActive(false);
        }
    }

    public void OpenKeyboard()
    {
        foreach(Transform key in gameObject.transform)
        {
            key.gameObject.SetActive(true);
        }
    }

}
