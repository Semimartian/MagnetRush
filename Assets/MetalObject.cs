using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalObject : MonoBehaviour
{
    //public bool isAttached;
    public Rigidbody rigidbody;
    [SerializeField] float speedReduction = 1f;
    public Magnet magnetAttached =null;
    public bool IsAttachedTo(Magnet magnet)
    {
        return magnetAttached == magnet;
    }

    public bool IsAttachedToSomeMagnet()
    {
        return magnetAttached != null;
    }

    public float SpeedReduction
    {
        get { return speedReduction; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (magnetAttached == null)
        {
            Magnet magnet = collision.gameObject.GetComponent<Magnet>();
            if (magnet!=null)
            {
                AttachTo(magnet);
            }
        }
        else
        {
            MetalObject metalObject = collision.gameObject.GetComponent<MetalObject>();
            if (metalObject != null)
            {
                if(metalObject.magnetAttached == null)
                {
                    metalObject.AttachTo(magnetAttached);

                }
            }
        }

    }

    private void AttachTo(Magnet magnet)
    {
        magnetAttached = magnet;
        rigidbody.isKinematic = true;
        magnet.AttachMetalObject(this);
    }

    public void Detach()
    {
        magnetAttached.DetachMetalObject(this);
        magnetAttached = null;
        rigidbody.isKinematic = false;
    }
}
