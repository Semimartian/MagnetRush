using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform moveToTarget;
    [SerializeField] private Transform lookAtTarget;
    [SerializeField] private float zDistance=-10;

    private Transform myTransform;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveToPosition = lookAtTarget.position;
        float newZ = moveToPosition.z + zDistance;
        float newX =Mathf.Lerp( myTransform.position.x, moveToPosition.x,Time.deltaTime * 5f);

        myTransform.position = new Vector3(newX, myTransform.position.y, newZ);


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