using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 40f;
    private Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnAtTarget();
    }

    public void turnAtTarget(){
        //direction = target.position - transform.position;
        direction[1] -= rotationSpeed * Time.fixedDeltaTime;
        gameObject.transform.eulerAngles = direction;
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
