using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToCelebrity : MonoBehaviour
{
    [Header("Fan Movement Values")]
    [SerializeField] private float followSpeed = 1;
    [SerializeField] private float rotationSpeed = 1;

    private Vector3 direction;
    public Transform celebrityTransform;
    private new Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();    
    }

    private void Update() 
    {
        
        CalculateDiretcion();
        RotateFan();    
    }

    void FixedUpdate()
    {
        rigidbody.velocity = transform.forward*followSpeed*Time.deltaTime;
    }

    private void CalculateDiretcion()
    {
        direction = celebrityTransform.position-transform.position;
        direction.Normalize();
    }

    private void RotateFan()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),rotationSpeed*Time.deltaTime);
    }
}
