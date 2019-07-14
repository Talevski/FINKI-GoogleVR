using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip audioClip;
    private bool isGrown = false;

    public void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        audioClip = audioSource.clip;
    }
    public void growTree()
    {
        GetComponent<Animator>().SetBool("isAnimating", true);
        audioSource.PlayOneShot(audioClip, 1f);
        //GetComponentInParent<SentenceAssembler>().GetSentence(0);

        if(isGrown == false){
            GameManager.instance.incrementScore();

            int score = GameManager.instance.getScore();
            if(score <= 13){
                GetComponentInParent<SentenceAssembler>().GetSentence(score);
            }
            else{
                GetComponentInParent<SentenceAssembler>().GetSentence(14);
            }

            isGrown = true;
        }
        //audioSource.PlayOneShot(audioSource.clip, 1f);
        
    }
}
