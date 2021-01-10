using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PretendFriction : MonoBehaviour
{
    private Rigidbody myBody;
    private Transform myTransform;
    private float myMass;
    private float slideSpeed;
    private Vector3 velo;
    private Vector3 flatVelo;
    private Vector3 myRight;
    private Vector3 _vec3;

    public float theGrip = 100f;

    private void Start()
    {
        myBody = GetComponent<Rigidbody>();
        myMass = myBody.mass;
        myTransform = transform;
    }

    private void FixedUpdate()
    {
        myRight = myTransform.right;

        velo = myBody.velocity;
        flatVelo.x = velo.x;
        flatVelo.y = 0;
        flatVelo.z = velo.z;

        slideSpeed = Vector3.Dot(myRight, flatVelo);

        _vec3 = myRight * (-slideSpeed * myMass * theGrip);
        
        myBody.AddForce(_vec3 * Time.deltaTime);
    }
}
