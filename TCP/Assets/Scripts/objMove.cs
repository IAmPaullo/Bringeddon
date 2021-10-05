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
    [SerializeField] float degrees = 360f;
    [SerializeField] float speed = 10f;
    [SerializeField] FillTextInfo textInfo;
    public Transform cameraPos;
    [SerializeField] SceneHandler sm;
    Vector3 rot;
    Transform objSelected;
    int c = 0;


    private void Start()
    {
        objSelected = objHolder.AllObjects[c].transform;
        cameraPos.position = new Vector3(objSelected.position.x - 1, cameraPos.position.y, cameraPos.position.z);
    }

    private void Update()
    {
        objSelected.Rotate(new Vector2(0, degrees), speed * Time.deltaTime);
    }

    public void OnNext()
    {

        try
        {
            c++;
            objSelected = objHolder.AllObjects[c].transform;
            cameraPos.position = new Vector3(objSelected.position.x - 1, cameraPos.position.y, cameraPos.position.z);
            objSelected.GetComponent<FillTextInfo>().ChangeDesc();

        }
        catch (System.Exception)
        {

            Debug.Log("ඞඞඞඞඞඞ");
            c = 0;
            objSelected = objHolder.AllObjects[c].transform;
            cameraPos.position = new Vector3(objSelected.position.x -1, cameraPos.position.y, cameraPos.position.z);
        }
    }

    public void OnBack()
    {
        if (c > 0)
        {
            c--;
            objSelected = objHolder.AllObjects[c].transform;
            cameraPos.position = new Vector3(objSelected.position.x - 1, cameraPos.position.y, cameraPos.position.z);
            objSelected.GetComponent<FillTextInfo>().ChangeDesc();
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
