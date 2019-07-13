using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree : MonoBehaviour
{
    public AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }
    public void growTree()
    {
        GetComponent<Animator>().SetBool("isAnimating", true);
        audioSource.PlayOneShot(audioSource.clip, 1f);
    }
}
