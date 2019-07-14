using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 1f;
    public float walkingSpeed = 0.75f;
    private bool pointerInside = false;
    private bool readyToWalk = false;
    private bool stopWalking = false;
    private bool stopRolling = false;
    private float distance;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        distance = Vector3.Distance(transform.position, target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if(pointerInside && anim.GetBool("Open_Anim"))
        {
            turnAtTarget();
            
            walkToTarget();
        }
        if(distance >= 19f && anim.GetBool("Open_Anim")){
            turnAtTarget();
            
            rollToTarget();
        }

    }

    public void turnAtTarget(){
        Vector3 targetDir = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = rotationSpeed * Time.deltaTime;

        //Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        //Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        //Quaternion rotation = Quaternion.LookRotation(newDir);
        Quaternion rotation = Quaternion.LookRotation(targetDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime); 

        float diff = transform.rotation.eulerAngles.y - rotation.eulerAngles.y;
        if (Mathf.Abs (diff) <= 2f)
            readyToWalk = true;
    }

    public void walkToTarget(){
        if(readyToWalk && !stopWalking ){//&& pointerInside){
            anim.SetBool("Walk_Anim", true);
            transform.position += transform.forward * walkingSpeed * Time.deltaTime;
        }

        if(!pointerInside){
            anim.SetBool("Walk_Anim", false);
        }

        if(distance <= 7.5f){
            stopWalking = true;
            readyToWalk = false;
            anim.SetBool("Walk_Anim", false);
        }
        else{
            stopWalking = false;
        }
    }

    public void rollToTarget(){
        if(readyToWalk && !stopWalking && !pointerInside){
            anim.SetBool("Roll_Anim", true);
            transform.position += transform.forward * walkingSpeed * Time.deltaTime;
        }

        if(pointerInside){
            anim.SetBool("Roll_Anim", false);
        }

        if(distance <= 20f){
            stopWalking = true;
            readyToWalk = false;
            anim.SetBool("Roll_Anim", false);
        }
        else{
            stopWalking = false;
        }
    }

    public void pointerEnter(){
        pointerInside = true;
    }
    public void pointerExit(){
        pointerInside = false;
    }
}
