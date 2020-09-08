using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalObject : MonoBehaviour
{
    //public bool isAttached;
    public Rigidbody rigidbody;
    [SerializeField] float speedReduction = 1f;
    //public Magnet magnetAttached =null;
    /*public bool IsAttachedTo(Magnet magnet)
    {
        return magnetAttached == magnet;
    }

    public bool IsAttachedToSomeMagnet()
    {
        return magnetAttached != null;
    }*/

    public float SpeedReduction
    {
        get { return speedReduction; }
    }

    public List<MetalObject> metalObjectsTouching = new List<MetalObject>();
    private void OnCollisionEnter(Collision collision)
    {
        MetalObject metalObject = collision.gameObject.GetComponent<MetalObject>();
        if (metalObject != null)
        {
            if (!metalObjectsTouching.Contains(metalObject))
            {
                metalObjectsTouching.Add(metalObject);
            }

        }

        /*return;
        if (magnetAttached == null)
        {
            Magnet magnet = collision.gameObject.GetComponent<Magnet>();
            if (magnet!=null)
            {
                AttachTo(magnet, magnet.rigidbody);
            }
        }
        else
        {
            MetalObject metalObject = collision.gameObject.GetComponent<MetalObject>();
            if (metalObject != null)
            {
                if(metalObject.magnetAttached == null)
                {
                    metalObject.AttachTo(magnetAttached, this.rigidbody);

                }
            }
        }*/

    }

    private void OnCollisionExit(Collision collision)
    {
        MetalObject metalObject = collision.gameObject.GetComponent<MetalObject>();
        if (metalObject != null)
        {
            metalObjectsTouching.Remove(metalObject);
        }


    }
    //public float attraction;
    /*private void AttachTo(Magnet magnet, Rigidbody body)
    {
        return;
        magnetAttached = magnet;
        //rigidbody.isKinematic = true;
        magnet.AttachMetalObject(this);

        Joint joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = body;
    }
    */
    /*public void Detach()
    {
        return;

        magnetAttached.DetachMetalObject(this);
        Destroy(gameObject.GetComponent<Joint>());

        magnetAttached = null;
        rigidbody.isKinematic = false;
    }*/
}
