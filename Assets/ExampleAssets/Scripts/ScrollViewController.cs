using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewController : MonoBehaviour
{
    public GameObject sofaScrollView;
    public GameObject bedScrollView;
    public GameObject cabinetScrollView;
    public GameObject lightScrollView;
    public GameObject mirrorScrollView;
    public GameObject chairScrollView;
    public GameObject tableScrollView;

    public GameObject categorySlider; // 카테고리 슬라이더

    public void OnSofaButtonClicked()
    {
        sofaScrollView.SetActive(true);
        bedScrollView.SetActive(false);
        cabinetScrollView.SetActive(false);
        lightScrollView.SetActive(false);
        mirrorScrollView.SetActive(false);
        chairScrollView.SetActive(false);
        tableScrollView.SetActive(false);
        categorySlider.SetActive(false); // 카테고리 슬라이더 숨기기
    }

    public void OnBedButtonClicked()
    {
        sofaScrollView.SetActive(false);
        bedScrollView.SetActive(true);
        cabinetScrollView.SetActive(false);
        lightScrollView.SetActive(false);
        mirrorScrollView.SetActive(false);
        chairScrollView.SetActive(false);
        tableScrollView.SetActive(false);
        categorySlider.SetActive(false); // 카테고리 슬라이더 숨기기
    }

    public void OnCabinetButtonClicked()
    {
        sofaScrollView.SetActive(false);
        bedScrollView.SetActive(false);
        cabinetScrollView.SetActive(true);
        lightScrollView.SetActive(false);
        mirrorScrollView.SetActive(false);
        chairScrollView.SetActive(false);
        tableScrollView.SetActive(false);
        categorySlider.SetActive(false); // 카테고리 슬라이더 숨기기
    }

    public void OnLightButtonClicked()
    {
        sofaScrollView.SetActive(false);
        bedScrollView.SetActive(false);
        cabinetScrollView.SetActive(false);
        lightScrollView.SetActive(true);
        mirrorScrollView.SetActive(false);
        chairScrollView.SetActive(false);
        tableScrollView.SetActive(false);
        categorySlider.SetActive(false); // 카테고리 슬라이더 숨기기
    }

    public void OnMirrorButtonClicked()
    {
        sofaScrollView.SetActive(false);
        bedScrollView.SetActive(false);
        cabinetScrollView.SetActive(false);
        lightScrollView.SetActive(false);
        mirrorScrollView.SetActive(true);
        chairScrollView.SetActive(false);
        tableScrollView.SetActive(false);
        categorySlider.SetActive(false); // 카테고리 슬라이더 숨기기
    }

    public void OnChairButtonClicked()
    {
        sofaScrollView.SetActive(false);
        bedScrollView.SetActive(false);
        cabinetScrollView.SetActive(false);
        lightScrollView.SetActive(false);
        mirrorScrollView.SetActive(false);
        chairScrollView.SetActive(true);
        tableScrollView.SetActive(false);
        categorySlider.SetActive(false); // 카테고리 슬라이더 숨기기
    }

    public void OnTableButtonClicked()
    {
        sofaScrollView.SetActive(false);
        bedScrollView.SetActive(false);
        cabinetScrollView.SetActive(false);
        lightScrollView.SetActive(false);
        mirrorScrollView.SetActive(false);
        chairScrollView.SetActive(false);
        tableScrollView.SetActive(true);
        categorySlider.SetActive(false); // 카테고리 슬라이더 숨기기
    }
}
