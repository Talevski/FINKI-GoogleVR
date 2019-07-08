using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInstr : MonoBehaviour
{
    public bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveText()
    {
        if (flag)
        {
            RectTransform myRectTransform = GetComponent<RectTransform>();
            myRectTransform.localPosition -= Vector3.right;
            flag = false;
        }
        else
        {
            RectTransform myRectTransform = GetComponent<RectTransform>();
            myRectTransform.localPosition += Vector3.right;
            flag = true;
        }
        
    }
}
