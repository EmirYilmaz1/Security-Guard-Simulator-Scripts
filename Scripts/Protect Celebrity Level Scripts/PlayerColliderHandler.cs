using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderHandler : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject.CompareTag("Fans"))
        {
            Destroy(other.gameObject);
        }
   }
}
