using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public static ObjectHolder instance;

    Transform showTransform;

    public List<GameObject> EveryObjectList = new List<GameObject>();
    int c;



    private void Awake()
    {
        foreach (Transform o in transform)
        {
            EveryObjectList.Add(o.transform.gameObject);

        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            ReturnObj();
        }


    }

    private void ReturnObj()
    {
        c++;
        for (int i = 0; i < EveryObjectList.Count; i++)
        {

        }
    }
}
