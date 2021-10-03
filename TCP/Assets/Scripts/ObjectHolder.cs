using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{


    Transform showTransform;

    
    public GameObject[] AllObjects;
    int c;

    private void ReturnObj()
    {
        c++;

        if (c <= AllObjects.Length)
        {
            showTransform = AllObjects[c].gameObject.transform;
        
        }
        else
        {
            c = 0;
            return;
        }

    }
}
