using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public event Action OnShelfComplete;
    public bool isComplete;

    List<ShelfPlace> shelfPlaces = new List<ShelfPlace>();
    void Start()
    {
        AddList();
    }

    private void AddList()
    {
        foreach (Transform shefPlace in transform)
        {
            if(shefPlace.TryGetComponent<ShelfPlace>(out ShelfPlace shelfPlace))
            {
                shelfPlaces.Add(shefPlace.GetComponent<ShelfPlace>());
                shefPlace.GetComponent<ShelfPlace>().OnShelfChange += SearchAllShelfs;
            }
        }
    }

    public void SearchAllShelfs()
    {
        int fileCount = 0;
        int boxCount = 0;

        foreach(ShelfPlace shelf in shelfPlaces)
        {
            if(!shelf.IsEmpty)
            {
                if(shelf.transform.childCount == 0) return;


                if(shelf.transform.GetChild(0).gameObject.CompareTag("File"))
                {
                   fileCount++;
                    if(fileCount==3)
                    {
                        isComplete = true;
                        OnShelfComplete?.Invoke();
                    }
                }

                if(shelf.transform.GetChild(0).gameObject.CompareTag("Box"))
                {   
                    boxCount++;
                    if(boxCount == 3)
                    {
                        isComplete = true;
                        OnShelfComplete?.Invoke();
                    }
                }
            }
            else
            {
                isComplete = false;
            }

        }
    }

}
