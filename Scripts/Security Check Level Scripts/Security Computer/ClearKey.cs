using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClearKey : MonoBehaviour
{
    public UnityEvent ClearNumber;

    public void ClearKeyClicked()
    {
        ClearNumber?.Invoke();
    }
}
