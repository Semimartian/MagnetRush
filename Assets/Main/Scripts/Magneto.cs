using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Magneto : Magnet
{

    public override void Initialise()
    {
        base.Initialise();
        myTransform = transform;
        InvokeRepeating("UpdateDebugText", 1, 0.2f);
    }
    private void UpdateDebugText()
    {
        debugText.text = "Velocity: " + velocity.ToString("f3") + "\n" +
        "Attached: " + attachedObjects;
    }
    // Update is called once per frame
    private Transform myTransform;

    [SerializeField] float rotationPerSecond;
    [SerializeField] float defaultSpeed;
    [SerializeField] float velocity;
    [SerializeField] Text debugText;

    [SerializeField] private float currentBoostlessSpeed;

    private float lastSpeedCheck;
    [SerializeField] private float speedCheckInterval = 0.3f;
    [SerializeField] private int attachedObjects;
    private void FixedUpdate()
    {
       velocity = rigidbody.velocity.magnitude;

        //rigidbody.velocity = Vector3.zero;
        //if (!attached)
        {
            float mouseMovement = Input.GetAxisRaw("Mouse X");
            float deltaTime = Time.deltaTime;
            if (mouseMovement != 0)
            {
                // Debug.Log("mouseMovement>0");
                myTransform.Rotate(new Vector3
                    (0, rotationPerSecond * mouseMovement * deltaTime, 0));
            }
            if (Input.GetMouseButton(0))
            {
                rigidbody.AddForce(myTransform.forward * (currentBoostlessSpeed + speedBoost) * deltaTime, ForceMode.Force);
                //myTransform.Translate(Vector3.forward * currentSpeed * deltaTime);
            }

        }

        float time = Time.time;
        if (time > lastSpeedCheck + speedCheckInterval)
        {
            UpdateSpeed();
            lastSpeedCheck = time;
        }
    }
    private List<MetalObject> metalObjectsTouching = new List<MetalObject>();
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
    }

    private void OnCollisionExit(Collision collision)
    {
        MetalObject metalObject = collision.gameObject.GetComponent<MetalObject>();
        if (metalObject != null)
        {
            metalObjectsTouching.Remove(metalObject);
        }
    }
    // private List<MetalObject> attachedMetalObjects = new List<MetalObject>();
    /*public override void AttachMetalObject(MetalObject metalObject)
    {
        base.AttachMetalObject(metalObject);
        attachedMetalObjects.Add(metalObject);
        UpdateSpeed();
    }

    public override void DetachMetalObject(MetalObject metalObject)
    {
        base.DetachMetalObject(metalObject);
        attachedMetalObjects.Remove(metalObject);
        UpdateSpeed();
    }*/

    private List<MetalObject> metalObjectsAttachedToMagneto = new List<MetalObject>();

    private void UpdateSpeed()
    {
        currentBoostlessSpeed = defaultSpeed ;
        if (metalObjectsTouching.Count == 0)
        {
            attachedObjects = 0;
            return;
        }
        metalObjectsAttachedToMagneto.Clear();
        metalObjectsAttachedToMagneto.AddRange(metalObjectsTouching);
        bool newObjectsFound = true;
        int previousCount = 0;
        while (newObjectsFound)
        {
            newObjectsFound = false;
            int count = metalObjectsAttachedToMagneto.Count;
            for (int i = previousCount; i < count; i++)
            {
                MetalObject metalObject = metalObjectsAttachedToMagneto[i];
                foreach (MetalObject metalObjectTouchingMetalObject in metalObject.metalObjectsTouching)
                {
                    if (!metalObjectsAttachedToMagneto.Contains(metalObjectTouchingMetalObject))
                    {
                        metalObjectsAttachedToMagneto.Add(metalObjectTouchingMetalObject);
                        newObjectsFound = true;
                    }
                }
            }
            previousCount = count;
        }


        attachedObjects = metalObjectsAttachedToMagneto.Count;
        for (int i = 0; i < metalObjectsAttachedToMagneto.Count; i++)
        {
            currentBoostlessSpeed -= metalObjectsAttachedToMagneto[i].SpeedReduction;
        }
        /* return;

         currentSpeed = defaultSpeed;
         return;
         for (int i = 0; i < attachedMetalObjects.Count; i++)
         {
             currentSpeed -= attachedMetalObjects[i].SpeedReduction;
         }
         Debug.Log("attachedMetalObjects.Count:" + attachedMetalObjects.Count);

         Debug.Log("currentSpeed:" + currentSpeed);*/
    }

    /*private bool attached =false;
    private void OnCollisionEnter(Collision collision)
    {
        return;
        //if (magnetAttached == null)
        {
            Magnet magnet = collision.gameObject.GetComponent<Magnet>();
            if (magnet != null)
            {
                attached = true;
                rigidbody.isKinematic = true;

              //  AttachTo(magnet);
            }
        }


    }*/

    /* private void OnCollisionStay(Collision collision)
     {
         float time = Time.time;
         if (time > lastSpeedCheck+ speedCheckInterval)
         {
             for
             lastSpeedCheck = time;
         }
     }*/
    /* private void AttachTo(Magnet magnet)
     {
         magnet.AttachMetalObject(this);
     }*/
   [SerializeField] private float speedBoost;

    private void OnTriggerEnter(Collider other)
    {
        SpeedBooster speedBooster = other.GetComponent<SpeedBooster>();
        if (speedBooster != null)
        {
            speedBoost = speedBooster.SpeedBoost;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SpeedBooster speedBooster = other.GetComponent<SpeedBooster>();
        if (speedBooster != null)
        {
            speedBoost = 0;
        }
    }
}
