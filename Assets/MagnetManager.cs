using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetManager : MonoBehaviour
{
    private MetalObject[] metalObjects;
    //[SerializeField] private Transform magnet;
    private Magnet[] magnets;
    /*[SerializeField] private float minAttractionDistance=10;
    [SerializeField] private float maxAttractionSpeed = 10;*/

    // Start is called before the first frame update
    void Start()
    {
        metalObjects = FindObjectsOfType<MetalObject>();
        magnets = FindObjectsOfType<Magnet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float deltaTime = Time.deltaTime;
        ManageMetalObjects(deltaTime);
        ManageMagnetoAgainstMagnets(deltaTime);

    }

    private void ManageMetalObjects(float deltaTime)
    {
        for (int j = 0; j < magnets.Length; j++)
        {

            Vector3 magnetPosition = magnets[j].transform.position;
            for (int i = 0; i < metalObjects.Length; i++)
            {
                MetalObject metalObject = metalObjects[i];
                if (!metalObject.IsAttachedTo(magnets[j]))
                {

                    Transform metalObjectTransform = metalObject.transform;
                    float distanceFromMagnet = Vector3.Distance(magnetPosition, metalObjectTransform.position);
                    float magnetAttractionDistance = magnets[j].AttractionDistance;
                    if (distanceFromMagnet <= magnetAttractionDistance)
                    {
                        if (metalObject.IsAttachedToSomeMagnet())
                        {
                            metalObject.Detach();
                        }
                        float attractionSpeed =
                            (Mathf.Abs(distanceFromMagnet - magnetAttractionDistance) / magnetAttractionDistance) * magnets[j].AttractionForce;
                        //Debug.Log("attractionSpeed=" + attractionSpeed);

                        metalObjects[i].rigidbody.AddForce
                            ((magnetPosition - metalObjectTransform.position).normalized
                            * (attractionSpeed * deltaTime));
                    }
                }

            }
        }
       
    }
    [SerializeField] Magneto magneto;
    private void ManageMagnetoAgainstMagnets(float deltaTime)
    {
        Vector3 magnetoPosition = magneto.transform.position;

        for (int j = 0; j < magnets.Length; j++)
        {
            if(magnets[j] == magneto)
            {
                continue;//O4TODO:Optimise
            }
            Vector3 magnetPosition = magnets[j].transform.position;

            //Transform metalObjectTransform = metalObject.transform;
            float distanceFromMagnet = Vector3.Distance(magnetPosition, magnetoPosition);
            float magnetAttractionDistance = magnets[j].AttractionDistance;
            if (distanceFromMagnet <= magnetAttractionDistance)
            {
               //Debug.Log("Attracting Magneto" );

                /* if (metalObject.IsAttachedToSomeMagnet())
                 {
                     metalObject.Detach();
                 }*/
                float attractionSpeed =
                    (Mathf.Abs(distanceFromMagnet - magnetAttractionDistance) / magnetAttractionDistance) * magnets[j].AttractionForce;
                //Debug.Log("attractionSpeed=" + attractionSpeed);

                magneto.rigidbody.AddForce
                    ((magnetPosition - magneto.transform.position).normalized
                    * (attractionSpeed * deltaTime));
            }
          
        }

    }
}
