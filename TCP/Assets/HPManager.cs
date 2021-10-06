using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{

    [SerializeField] List<GameObject> icon = new List<GameObject>();
    [SerializeField] GameObject prefab;
    [SerializeField] Transform holder;




    private void Start()
    {
        
    }


    public void RemoveIcon()
    {
        var c = icon.Count;
        icon[c].SetActive(false);
    }

    public void Fill(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(prefab, holder);
            //icon[i] = holder.GetChild(i).gameObject;
        }
    }
}
