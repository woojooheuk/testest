using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARObjectController : MonoBehaviour
{
    private GameObject selectedObject;
    private Quaternion initialRotation; // 초기 회전값 저장

    public Slider scaleSlider;
    public Slider rotationSlider;

    public void SetSelectedObject(GameObject obj)
    {
        selectedObject = obj;
        // 초기 회전값 저장
        initialRotation = obj.transform.rotation;
    }

    public void UpdateScale()
    {
        if (selectedObject != null)
        {
            float scale = scaleSlider.value;
            selectedObject.transform.localScale = Vector3.one * scale;
        }
    }

    public void UpdateRotation()
    {
        if (selectedObject != null)
        {
            float angle = rotationSlider.value;
            // y 축을 기준으로 회전하기 위해 Quaternion.Euler 함수를 사용하여 회전값을 만듭니다.
            Quaternion rotation = Quaternion.Euler(selectedObject.transform.rotation.eulerAngles.x, angle, selectedObject.transform.rotation.eulerAngles.z);
            selectedObject.transform.rotation = rotation;
        }
    }
}

