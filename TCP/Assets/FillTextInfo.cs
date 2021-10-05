using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class FillTextInfo : MonoBehaviour
{
    public string nameObject;


    [TextArea]
    public string description;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descText;

    public void ChangeDesc()
    {
        nameText.text = nameObject;
        descText.text = description;
    }

    private void Start()
    {
        ChangeDesc();
    }
}
