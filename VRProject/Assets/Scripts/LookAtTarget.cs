using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 1f;
    public float walkingSpeed;
    private bool pointerInside = false;
    private bool readyToWalk = false;
    private bool stopWalking = false;
    private bool isRolling = false;
    private bool distanceWarning = false;
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

        if(pointerInside && anim.GetBool("Open_Anim") && !isRolling)
        {
            turnAtTarget();
            
            walkToTarget();
        }
        if(!pointerInside){
            anim.SetBool("Walk_Anim", false);
        }
        if(distance >= 19f && anim.GetBool("Open_Anim")){
            turnAtTarget();
            
            rollToTarget();
        }
        if(distance >= 26f && distance <= 26.25f){
            if(distanceWarning){
                GetComponent<SentenceAssembler>().GetSentence(4);
                distanceWarning = false;
            }
            else{
                GetComponent<SentenceAssembler>().GetSentence(3);
                distanceWarning = true;
            }
        
        if(distance >= 35f && !anim.GetBool("Open_Anim")){
            GetComponent<SentenceAssembler>().GetSentence(3);
        }
            
        }

    }

    public void turnAtTarget(){
        anim.SetBool("Turn_Anim", true);
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

        if(readyToWalk == false && Mathf.Abs(diff) > 3f && distance <= 15){
            GetComponent<SentenceAssembler>().GetSentence(6);
        }
        if (Mathf.Abs(diff) <= 2f)
            readyToWalk = true;
        anim.SetBool("Turn_Anim", false);
    }

    public void walkToTarget(){
        if(readyToWalk && !stopWalking){
            anim.SetBool("Roll_Anim", false);
            anim.SetBool("Walk_Anim", true);
            transform.position += transform.forward * walkingSpeed * Time.deltaTime;
<<<<<<< Updated upstream
            GetComponent<SentenceAssembler>().GetSentence(2);
=======
>>>>>>> Stashed changes
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
            transform.position += transform.forward * (walkingSpeed * 2) * Time.deltaTime;
            isRolling = true;
            if(distance >= 21){
                GetComponent<SentenceAssembler>().GetSentence(5);
            }
        }

        //if(pointerInside){
        //    anim.SetBool("Roll_Anim", false);
        //}

        if(distance <= 20f){
            stopWalking = true;
            readyToWalk = false;
            anim.SetBool("Roll_Anim", false);
            isRolling = false;
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
        anim.SetBool("Walk_Anim", false);
    }
}
