using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ObjMove : MonoBehaviour
{
    [SerializeField] GlossarioInput glossarioInputActions;
    [SerializeField] RotateMode rotMode;
    [SerializeField] ObjectHolder objHolder;
    [SerializeField] float speed;
    public Transform cameraPos;
    [SerializeField] SceneHandler sm;
    Vector3 rot;
    Transform objSelected;
    int c = 0;


    private void Start()
    {
        objSelected = objHolder.AllObjects[c].transform;
        cameraPos.position = new Vector3(objSelected.position.x, objSelected.position.y, cameraPos.position.z);
    }

    private void Update()
    {
        //cameraPos.position = new Vector3(objSelected.position.x, objSelected.position.y, objSelected.position.z - 3);
    }

    public void OnRotate(InputValue input)
    {

        Vector3 inputVector = input.Get<Vector2>();
        rot = inputVector;
        objSelected.DORotate(new Vector2(-rot.y * speed, -rot.x * speed), Time.deltaTime, rotMode);

    }

    public void OnNext()
    {

        c++;
        objSelected = objHolder.AllObjects[c].transform;
        cameraPos.position = new Vector3(objSelected.position.x, objSelected.position.y, cameraPos.position.z);


        Debug.Log("aaaaaaaaaaa");



    }

    public void OnBack()
    {
        if (c > 0)
        {
            c--;
            objSelected = objHolder.AllObjects[c].transform;
            cameraPos.position = new Vector3(objSelected.position.x, objSelected.position.y, cameraPos.position.z);
        }

        if (c < 0 || c > objHolder.AllObjects.Length)
        {
            c = 0;
            objSelected = objHolder.AllObjects[0].transform;
        }
    }


    public void OnReturn()
    {
        sm.LoadScene(sm.ReturnSceneIndex() - 1);
    }

}
