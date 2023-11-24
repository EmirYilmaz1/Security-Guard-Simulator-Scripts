using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLevelPlayerRaycast : MonoBehaviour
{
    Ray ray;
    RaycastHit[] hits;

    private DragableObject dragableObject;
    private Transform transform;

    float xPosition;

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hits = Physics.RaycastAll(ray);

            foreach(RaycastHit hit in hits)
            {
                if(hit.collider.TryGetComponent<DragableObject>(out DragableObject component))
                {
                    component.isHoldingByPlayer = true;
                    dragableObject = component;
                }
            }
        }

        if(Input.GetMouseButton(0))
        {
            xPosition = Input.mousePosition.x;
        }


        if(Input.GetMouseButtonUp(0))
        {
            if(dragableObject !=null)
            {
                dragableObject.isHoldingByPlayer = false;
                dragableObject = null;
            }
        }
    
    }
}
