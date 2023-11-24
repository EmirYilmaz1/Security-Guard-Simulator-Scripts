using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerArrow : MonoBehaviour
{
    public event Action OnClick;

    [SerializeField] private Transform endPosition;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;
    [SerializeField] private AttackHandler attackHandler;

    Vector3 vector;


    private float arrowDistance;
    public float ArrowDistance{get{return arrowDistance;}}
    private float tau;

    void Start()
    {
        tau = Mathf.PI*2;
        vector = transform.position;
    }

    void Update()
    {
        float cycle =Time.time/speed;
        float sin = (Mathf.Sin(tau*cycle)+1)/2;
        Vector3 offsetPos = offset*sin;

        transform.position = vector + offsetPos;

       arrowDistance = transform.position.x-endPosition.position.x;

       if(Input.GetMouseButtonDown(0))
        {

            attackHandler.PlayFistAnimation();
            OnClick?.Invoke();
        }

    }


}
