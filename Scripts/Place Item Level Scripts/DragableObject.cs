using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour
{

    public bool isHoldingByPlayer;
    public Transform holdPosition;

    private bool canBeDropped;
    private ShelfPlace currentShelf;
    private ShelfPlace nextShelf;

    private void Awake() 
    {
      currentShelf = GetComponentInParent<ShelfPlace>();
      currentShelf.IsEmpty = false;
    }

    void Update()
    {
        if(isHoldingByPlayer)
        {   
            canBeDropped = true;
            transform.position = Vector3.Lerp(transform.position,new Vector3((Input.mousePosition.x/Screen.width)*4, Screen.height/Input.mousePosition.y*1f,2), 3*Time.deltaTime);
            return;
        }

        if(canBeDropped && !isHoldingByPlayer)
        {
           StartCoroutine(GoToShelf());
            
        }
    }

    private IEnumerator GoToShelf()
    {
        if(nextShelf != null)
        {
            currentShelf.IsEmpty = true;

            currentShelf = nextShelf;

            transform.SetParent(currentShelf.transform);
            currentShelf.IsEmpty = false;
            
            nextShelf = null;
        }
        Vector3 startPosition = transform.parent.transform.TransformPoint(0,0,0);
        transform.position = Vector3.Lerp(transform.position,startPosition, 2*Time.deltaTime);
        yield return new WaitForEndOfFrame();
        canBeDropped = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(isHoldingByPlayer&&other.gameObject.CompareTag("Shelf"))
        {
            if(other.TryGetComponent<ShelfPlace>(out ShelfPlace shefPlace))
            {
                if(shefPlace.IsEmpty)
                {
                    nextShelf = shefPlace;
                }
            }
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Shelf"))
        {
            if(other.TryGetComponent<ShelfPlace>(out ShelfPlace shefPlace))
            {
                if( nextShelf == shefPlace)
                {
                    nextShelf = null;
                }
            }
        }  
    }

    

    
}
