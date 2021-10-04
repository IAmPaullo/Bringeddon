using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class objMove : MonoBehaviour
{
    [SerializeField] GlossarioInput glossarioInputActions;
    [SerializeField] RotateMode rotMode;
    [SerializeField] ObjectHolder objHolder;
    [SerializeField] float speed;
    [SerializeField] Transform cameraPos;
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
        cameraPos.position = new Vector3(objSelected.position.x, objSelected.position.y, cameraPos.position.z);
    }

    public void OnRotate(InputValue input)
    {

        Vector3 inputVector = input.Get<Vector2>();
        rot = inputVector;

        //objSelected.Rotate(new Vector3(0, rot.x * speed , rot.y * speed ));

        objSelected.DORotate(new Vector2(-rot.y * speed, -rot.x * speed), Time.deltaTime, rotMode);

        //objSelected.DORotate(new Vector2(rot.y * speed * Time.deltaTime, rot.x * speed * Time.deltaTime),
        //    speed * Time.deltaTime, rotMode);

    }

    public void OnNext()
    {
        try
        {
            c++;
            objSelected = objHolder.AllObjects[c].transform;
        }
        catch (System.Exception)
        {

            
            throw;
        }
            
        

    }

    public void OnBack()
    {
        if (c > 0)
        {
            c--;
            objSelected = objHolder.AllObjects[c].transform;
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
