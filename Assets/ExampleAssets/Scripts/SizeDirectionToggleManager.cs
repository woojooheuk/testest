using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeDirectionToggleManager : MonoBehaviour
{
    public GameObject scaleSlider;
    public GameObject rotationSlider;

    private bool isSizePanelActive = false;
    private bool isDirectionPanelActive = false;

    public void ToggleSizePanel()
    {
        isSizePanelActive = !isSizePanelActive;
        scaleSlider.SetActive(isSizePanelActive);
    }

    public void ToggleDirectionPanel()
    {
        isDirectionPanelActive = !isDirectionPanelActive;
        rotationSlider.SetActive(isDirectionPanelActive);
    }
}
