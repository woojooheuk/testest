using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Material_Controller : MonoBehaviour
{
    public Material[] exampleMat = new Material[2];

    int i = 0;

    public void ChangeMat()
    {
        i = ++i % 2;

        gameObject.GetComponent<MeshRenderer>().material = exampleMat[i];
    }
}