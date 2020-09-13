using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float attractionForce;
    public Transform attrractivePoint;
    public Rigidbody rigidbody;


    public virtual void Initialise()
    {
        attractionDistance = attractionSphere.radius;
        if (attrractivePoint == null)
        {
            attrractivePoint = transform;
        }
        if(!(this is Magneto))
        {
            //gameObject.SetActive(false);
        }
        //attractionSphere.isTrigger = true;
       Destroy(attractionSphere);
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
