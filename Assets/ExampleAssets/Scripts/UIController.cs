using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject[] uiElements; // UI 요소를 여기에 추가하세요.
    public GameObject[] scrollViews; // 스크롤뷰 요소를 여기에 추가하세요.
    public GameObject fullButtonPanel;  
    public GameObject fullButton; // FULL 버튼을 여기에 할당하세요.

    private bool isUIEnabled = true; // UI 요소가 활성화되어 있는지 여부를 저장하는 변수
    private bool isScrollViewEnabled = true; // 스크롤뷰가 활성화되어 있는지 여부 저장 변수 
    private bool isInitialToggle = true;

    public void ToggleUI()
    {
        // UI 요소의 활성화 상태를 토글합니다.
        isUIEnabled = !isUIEnabled;
        isScrollViewEnabled = !isScrollViewEnabled;

        // 모든 UI 요소를 순회하면서 활성화 상태를 설정합니다.
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(isUIEnabled);
        }

        foreach (GameObject scrollView in scrollViews)
        {
            scrollView.SetActive(false);
        }

        if (isInitialToggle && !isUIEnabled)
        {  
            isInitialToggle = true;
            fullButtonPanel.SetActive(false);
            fullButton.SetActive(false);
            StartCoroutine(ReenableFullButtonAfterDelay(3f));

        }

        else if (!isInitialToggle)
        {
            isInitialToggle = false;
            fullButtonPanel.SetActive(true);
            fullButton.SetActive(true);
            StartCoroutine(ReenableFullButtonAfterDelay(3f));

        }       
    }

    private IEnumerator ReenableFullButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        fullButtonPanel.SetActive(true);
        fullButton.SetActive(true);
    }
}

