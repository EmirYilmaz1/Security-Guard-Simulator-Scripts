using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceItemWinLoseUIManager : MonoBehaviour
{
    [Header("Win Canvas")]
    [SerializeField] private Canvas winCanvas;

    ShelfManager[] shelfManagers; 
    void Start()
    {
        shelfManagers =FindObjectsOfType<ShelfManager>();
        foreach(ShelfManager curentShelfManager in shelfManagers)
        {
            curentShelfManager.OnShelfComplete += OpenWinCanvas;
        }
    }

    
    private void OpenWinCanvas()
    {
        int shelfsThatComplete = 0;
        
        foreach(ShelfManager currentShelfManager in shelfManagers)
        {
            if(currentShelfManager.isComplete)
            {
                shelfsThatComplete++;
                
                if(shelfsThatComplete==2)
                {
                    winCanvas.enabled = true;
                    Invoke(nameof(FreezeTheTime),1f);
                }               
            }
        }
    }

    private void FreezeTheTime()
    {
        Time.timeScale = 0;
    }

}
