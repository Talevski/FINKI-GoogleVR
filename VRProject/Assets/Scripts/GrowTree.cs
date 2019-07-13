using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree : MonoBehaviour
{
    public void growTree()
    {
        GetComponent<Animator>().SetBool("isAnimating", true);
    }
}
