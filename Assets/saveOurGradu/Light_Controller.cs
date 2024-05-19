using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Light_Controller : MonoBehaviour
{
    public GameObject lightControlObject;

    public Slider intensitySlider;
    public Slider distanceSlider;
    public Slider temperatureSlider;

    // Start is called before the first frame update
    void Start()
    {
        intensitySlider.onValueChanged.AddListener(ChangeIntensity);
        distanceSlider.onValueChanged.AddListener(ChangeDistance);
        temperatureSlider.onValueChanged.AddListener(ChangeTemperature);
    }
                                     //ÃÐºÒ ¹é¿­µî ÅÖ½ºÅÏ·¥ÇÁ ¾ÆÄ§/¿ÀÈÄÅÂ¾ç±¤ ÅÂ¾ç±¤ ÇÃ·¡½Ã ±¸¸§³¤ ÁÖ±¤ ÇÏ´Ã
    private float[] temperatureValues = { 1900f, 2800f, 3200f, 4500f, 5500f, 6000f, 6800f };
    public void SetLastClickedObject(GameObject obj)
    {
        lightControlObject = obj;

        if(lightControlObject != null)
        {
            Light pointLight = lightControlObject.GetComponentInChildren<Light>();
            if(pointLight != null)
            {
                intensitySlider.value = pointLight.intensity;
                distanceSlider.value = lightControlObject.transform.position.z;
                temperatureSlider.value = GetTemperatureIndex(pointLight.colorTemperature);
            }
        }
    }
    void ChangeIntensity(float newLightPower)
    {
        if (lightControlObject != null)
        {
            Light pointLight = lightControlObject.GetComponentInChildren<Light>();
            if (pointLight != null)
            {
                pointLight.intensity = newLightPower;
                pointLight.range = newLightPower;

                intensitySlider.value = newLightPower;
                
            }
        }
    }

    void ChangeDistance(float newDistance)
    {
        if (lightControlObject != null)
        {
            Vector3 newPosition = lightControlObject.transform.position;
            newPosition.z = newDistance;
            lightControlObject.transform.position = newPosition;

            distanceSlider.value = newDistance;
        }
    }
    void ChangeTemperature(float newTemperature)
    {
        if(lightControlObject != null)
        {
            Light pointLight = lightControlObject.GetComponentInChildren<Light>();
            if(pointLight != null)
            {
                int step = Mathf.RoundToInt(newTemperature);
                float temperature = temperatureValues[Mathf.Clamp(step, 0, temperatureValues.Length - 1)];
                pointLight.colorTemperature = temperature;
            }
        }
    }
    int GetTemperatureIndex(float temperature)
    {
        for(int i = 0; i < temperatureValues.Length; i++)
        {
            if(Mathf.Approximately(temperatureValues[i], temperature))
            {
                return i;
            }
        }
        return 0;
    }
}
