using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Light_Controller : MonoBehaviour
{
    public GameObject lightControlObject;
    public Light pointLight;

    public float intensity;
    public Slider intensitySlider;

    public float range;
    public Slider rangeSlider;

    public float distance;
    public Slider distanceSlider;

    // Start is called before the first frame update
    void Start()
    {
        intensitySlider.onValueChanged.AddListener(ChangeIntensity);
        rangeSlider.onValueChanged.AddListener(ChangeRange);
        distanceSlider.onValueChanged.AddListener(ChangeDistance);
    }

    void ChangeIntensity(float newIntensity)
    {
        pointLight.intensity = newIntensity;
        pointLight.range = newIntensity;
    }

    void ChangeRange(float newRange)
    {
        pointLight.range = newRange;
    }
    void ChangeDistance(float newDistance)
    {
        Vector3 newPosition = lightControlObject.transform.position;
        newPosition.z = newDistance;
        lightControlObject.transform.position = newPosition;
    }
}
