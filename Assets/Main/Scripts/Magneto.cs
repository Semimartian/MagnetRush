using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magneto : Magnet
{
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        UpdateSpeed();
    }

    // Update is called once per frame
    private Transform myTransform;

    [SerializeField] float rotationPerSecond;
    [SerializeField] float defaultSpeed;
    public Rigidbody rigidbody;

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!attached)
        {
            float mouseMovement = Input.GetAxisRaw("Mouse X");
            float deltaTime = Time.deltaTime;
            if (mouseMovement != 0)
            {
                // Debug.Log("mouseMovement>0");
                myTransform.Rotate(new Vector3
                    (0, rotationPerSecond * mouseMovement * deltaTime, 0));
            }
            myTransform.Translate(Vector3.forward * currentSpeed * deltaTime);
        }


    }

    private List<MetalObject> attachedMetalObjects = new List<MetalObject>();
    private float currentSpeed;
    public override void AttachMetalObject(MetalObject metalObject)
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
    }
    private void UpdateSpeed()
    {
        currentSpeed = defaultSpeed;
        for (int i = 0; i < attachedMetalObjects.Count; i++)
        {
            currentSpeed -= attachedMetalObjects[i].SpeedReduction;
        }
        Debug.Log("attachedMetalObjects.Count:" + attachedMetalObjects.Count);

        Debug.Log("currentSpeed:" + currentSpeed);
    }

    private bool attached =false;
    private void OnCollisionEnter(Collision collision)
    {
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


    }

   /* private void AttachTo(Magnet magnet)
    {
        magnet.AttachMetalObject(this);
    }*/
}
