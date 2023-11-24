using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Touch touch;
    
    private Vector3 firstTouchPosition;
    private Vector3 lastTouchPosition;

    private bool isDragging;
 
    private Vector3 dir;

    [Header("Player Stats & Components")]
    [SerializeField] private float rotationSpeed = 2;
    [SerializeField] private float playerMoveSpeed = 1000;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Animator playerAnimator;

    [Header("Celebrity Stats & Component")]
    [SerializeField] private Rigidbody celebrityRigidbody;
    [SerializeField] private float celebrityMoveSpeed = 800;
    [SerializeField] private Animator celebrityAnimator;
 


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
           touch = Input.GetTouch(0);

           if(touch.phase == TouchPhase.Began)
           {
               firstTouchPosition = touch.position;
                playerAnimator.CrossFade("Walk",0.1f);
                celebrityAnimator.CrossFade("Walk",0.1f);
               isDragging = true;
           }
        }

       if(isDragging)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                lastTouchPosition = touch.position;

                CalculateDiretcion();
                SetRotation();

            }

            if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
                playerAnimator.CrossFade("Idle",0.1f);
                celebrityAnimator.CrossFade("Idle",0.1f);
                return;
            }

            MoveWithCelebrity();
        }

    }

    private void MoveWithCelebrity()
    {
        playerRigidbody.velocity = transform.forward * Time.deltaTime * playerMoveSpeed;
        celebrityRigidbody.velocity = celebrityRigidbody.transform.forward * Time.deltaTime * celebrityMoveSpeed;
    }

    private void SetRotation()
    {
        Quaternion lookPos = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookPos, rotationSpeed * Time.deltaTime);
    }

    private void CalculateDiretcion()
    {
        dir = firstTouchPosition - lastTouchPosition;
        dir.Normalize();
        dir.z =dir.y;
        
        if(dir.z>0)
        {
            dir.z = -dir.z;
        }

        dir.y = 0;
    }
}
