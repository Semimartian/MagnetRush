﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float attractionForce;
    public Rigidbody rigidbody;

    private void Start()
    {
        Initialise();
    }

    public virtual void Initialise()
    {
        attractionDistance = attractionSphere.radius;
        //Destroy(attractionSphere);
    }
    public float AttractionForce
    {
        get { return attractionForce; }
    }

     private float attractionDistance;
    [SerializeField] private SphereCollider attractionSphere;
    public float AttractionDistance
    {
        get { return attractionDistance; }
    }
    /*public virtual void AttachMetalObject(MetalObject metalObject)
    {
        //metalObject.transform.parent = transform;

    }

    public virtual void DetachMetalObject(MetalObject metalObject)
    {
        // metalObject.transform.parent = null;
        //metalObject.joint.connectedBody = null;
       // metalObject.Detach();
    }*/
}
