using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    public float distance = 8.0f;
    public float height = 4.0f;
    public float smoothSpeed = 0.5f;

    private Vector3 smoothVelocity;


    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref smoothVelocity, smoothSpeed);
        transform.LookAt(target.position);
    }
}
