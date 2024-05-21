using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastClickedLightObj : MonoBehaviour
{
    private Light_Controller lightController;
    // Start is called before the first frame update
    void Start()
    {
        lightController = GameObject.FindObjectOfType<Light_Controller>();
    }

    private void OnMouseDown()
    {
        lightController.SetLastClickedObject(gameObject);
    }
}