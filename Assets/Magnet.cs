using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float attractionForce;
    public float AttractionForce
    {
        get { return attractionForce; }
    }

    [SerializeField] private float attractionDistance;
    public float AttractionDistance
    {
        get { return attractionDistance; }
    }
    public virtual void AttachMetalObject(MetalObject metalObject)
    {
        metalObject.transform.parent = transform;
    }

    public virtual void DetachMetalObject(MetalObject metalObject)
    {
        metalObject.transform.parent = null;
    }
}
