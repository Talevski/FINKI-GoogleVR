using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseBall : MonoBehaviour
{
    Vector3 rot = Vector3.zero;
    float rotSpeed = 40f;
    Animator anim;

    private AudioSource audioSource;

    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.eulerAngles = rot;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openCloseBall()
    {
        if (!anim.GetBool("Open_Anim"))
        {
            anim.SetBool("Open_Anim", true);
            //
            //audioSource.PlayOneShot(audioSource.clip, 1f);
            GetComponent<SentenceAssembler>().GetSentence(0);
        }
        else
        {
            anim.SetBool("Open_Anim", false);
            GetComponent<SentenceAssembler>().GetSentence(1);
        }
    }
}
