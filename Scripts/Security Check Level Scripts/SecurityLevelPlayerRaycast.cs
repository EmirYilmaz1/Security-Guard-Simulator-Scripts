using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityLevelPlayerRaycast : MonoBehaviour
{
    public event Action<int> OnKeyClicked;
    private Ray ray;
    private RaycastHit[] raycastHits;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           raycastHits = Physics.RaycastAll(ray);

           foreach(RaycastHit hit in raycastHits)
           {
                if(hit.collider.TryGetComponent<Key>(out Key key))
                {
                    int keyNumber = key.KeyClicked();
                    OnKeyClicked?.Invoke(keyNumber);
                    break;
                }
                
                if(hit.collider.TryGetComponent<ClearKey>(out ClearKey clearKey))
                {
                    clearKey.ClearKeyClicked();
                    break;
                }

                if(hit.collider.TryGetComponent<DecisionButton>(out DecisionButton decisionButton))
                {
                    decisionButton.PressedButton();
                }
           }
        }
    }
}
