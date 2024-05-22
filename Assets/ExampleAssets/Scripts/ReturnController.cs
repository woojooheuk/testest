using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnController : MonoBehaviour
{
    public GameObject[] categoryScrollViews; // 모든 카테고리 스크롤뷰의 배열

    public GameObject categoryScrollView; // Categori ScrollView의 참조

    public void GoBackToCategory()
    {
        // 모든 카테고리 스크롤뷰를 비활성화합니다.
        foreach (GameObject scrollView in categoryScrollViews)
        {
            scrollView.SetActive(false);
        }

        // Categori ScrollView를 활성화합니다.
        categoryScrollView.SetActive(true);
    }
}
