using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Offset
{
    public Offset(Vector3 position , Vector3 angle)
    {
        this.position = position;
        this.angle = angle;
    }

    public Vector3 position;
    public Vector3 angle;

}
public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Offset offset;

   [SerializeField] private Transform lookAtTarget;

    //[SerializeField] private float zDistance=-10;

    private Transform myTransform;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveToPosition = lookAtTarget.position + offset.position;
        //float newZ = moveToPosition.z + zDistance;
        //float newX =Mathf.Lerp( myTransform.position.x, moveToPosition.x,Time.deltaTime * 5f);

        myTransform.position = moveToPosition;// new Vector3(newX, myTransform.position.y, newZ);

        //myTransform.rotation = offset.angle.eua
    }
}
/*Vector3 myEuler = myTransform.rotation.eulerAngles;
float yAngle = Mathf.Lerp(lookAttarget.rotation.eulerAngles.y, myEuler.y,0.2f*Time.deltaTime);*/
/*myTransform.rotation = 
    Quaternion.Lerp(lookAttarget.rotation, myTransform.rotation, 0.8f );*/

//myEuler.y = yAngle;
// myTransform.rotation = Quaternion.Euler(myEuler);
//myTransform.LookAt(lookAttarget);

//myTransform.rotation = Quaternion.Euler(myEuler);