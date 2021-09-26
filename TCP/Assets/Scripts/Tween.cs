using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class Tween : MonoBehaviour
{
    [SerializeField] Transform objSelect;
    [SerializeField] float speed;
    [SerializeField] RotateMode rot;
    [SerializeField]ObjectHolder objHolder;
    Vector3 rotation;
    int c;
    

  

    private void Start()
    {
        objSelect = objHolder.AllObjects[0].transform;
    }

   

    public void NextObject()
    {
        c++;

        if (c <= objHolder.AllObjects.Length)
        {
            objSelect = objHolder.AllObjects[c].transform;
        }



    }

    public void OnRotate(InputValue input)
    {
        Vector3 inputVector = input.Get<Vector2>();
        rotation = inputVector;

        Debug.Log(rotation);

    }

    public void OnStuff()
    {
        
        objSelect.DORotate(new Vector3(0, 0, 0), Time.deltaTime, rot);
    }

  
}
