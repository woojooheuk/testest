using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Material_Controller : MonoBehaviour
{
    public GameObject targetObject;
    public Material[] exampleMat = new Material[2];
    private int i;

    // 각 버튼 클릭 시 호출될 함수
    public void ChangeMaterial(Button clickedButton)
    {
        Debug.Log("?2");
        string buttonTag = clickedButton.tag;
        Renderer renderer = targetObject.GetComponent<Renderer>();
        switch (clickedButton.tag)
        {
            case "Mat1":
                i = 0;
                break;

            case "Mat2":
                i = 1;
                Debug.Log("?");
                break;

        }

        renderer.material = exampleMat[i];
    }
}