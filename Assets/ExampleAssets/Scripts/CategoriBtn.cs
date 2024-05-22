using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoriBtn : MonoBehaviour
{
    public GameObject categoriScrollView;
    public GameObject[] otherScrollViews; // 다른 스크롤뷰들을 여기에 할당하세요.

    private bool isCategoriScrollViewActive = false;

    public void ToggleCategoriScrollView()
    {
        isCategoriScrollViewActive = !isCategoriScrollViewActive;
        categoriScrollView.SetActive(isCategoriScrollViewActive);

        // 카테고리 스크롤뷰가 비활성화되었을 때만 다른 스크롤뷰들도 비활성화합니다.
        if (!isCategoriScrollViewActive)
        {
            foreach (GameObject scrollView in otherScrollViews)
            {
                scrollView.SetActive(false);
            }
        }
    }
}



