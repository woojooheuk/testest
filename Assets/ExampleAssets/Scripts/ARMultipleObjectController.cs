using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARMultipleObjectController : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager arRaycastManager;

    internal void TogglePlacementEnabled()
    {
        throw new NotImplementedException();
    }

    [SerializeField]
    Camera arCamera;

    internal void TogglePlacementEnabled(bool v)
    {
        throw new NotImplementedException();
    }

    [SerializeField]
    RemoveObjectController removeObjectController; // RemoveObjectController 참조

    [SerializeField]
    ARObjectController objectController; // ARObjectController 참조

    GameObject selectedPrefab;
    ARObject selectedObj;

    private static List<ARRaycastHit> arHits = new List<ARRaycastHit>();
    private static RaycastHit physicsHit;

    private List<GameObject> placedObjects = new List<GameObject>(); // 가장 최근에 생성된 오브젝트들을 저장하는 리스트

    private Quaternion initialRotation; // 초기 회전 값을 저장하기 위한 변수

    private void Awake()
    {
        selectedPrefab = arRaycastManager.raycastPrefab;
    }

    public void SetSelectedPrefab(GameObject selectedPrefab)
    {
        this.selectedPrefab = selectedPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = touch.position;

        if (IsPointOverUIObject(touchPosition))
        {
            return;
        }

        // 객체가 선택되면 Selected
        if (touch.phase == TouchPhase.Began)
        {
            SelectARObject(touchPosition);
        }

        else if (touch.phase == TouchPhase.Ended)
        {
            if (selectedObj)
            {
                selectedObj.Selected = false;
                initialRotation = selectedObj.transform.rotation; // 터치 종료 시 이전 회전 값을 저장
            }
        }

        SelectARPlane(touchPosition);
    }

    private bool SelectARObject(Vector2 touchPosition)
    {
        Ray ray = arCamera.ScreenPointToRay(touchPosition);

        if (Physics.Raycast(ray, out physicsHit))
        {
            selectedObj = physicsHit.transform.GetComponent<ARObject>();

            if (selectedObj)
            {
                selectedObj.Selected = true;
                // 선택된 오브젝트를 ARObjectController에 설정
                objectController.SetSelectedObject(selectedObj.gameObject);
                // 선택 시 이전 회전 값을 저장 
                initialRotation = selectedObj.transform.rotation;
                return true;
            }
        }

        return false;
    }

    private void SelectARPlane(Vector2 touchPosition)
    {
        // 빈 평면이 선택돠면 ARraycast 사용 
        if (arRaycastManager.Raycast(touchPosition, arHits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = arHits[0].pose;

            if (!selectedObj)
            {
                var newARObj = Instantiate(selectedPrefab, hitPose.position, hitPose.rotation);
                selectedObj = newARObj.AddComponent<ARObject>();
                placedObjects.Add(newARObj); // 리스트에 추가
                removeObjectController.AddPlacedObject(newARObj); // RemoveObjectController에 오브젝트 추가
            }

            else if (selectedObj.Selected)
            {
                selectedObj.transform.position = hitPose.position;
                selectedObj.transform.rotation = initialRotation; // 터치로 이동할 때 이전 회전 값을 유지
            }

        }
    }

    bool IsPointOverUIObject(Vector2 pos)
    {
        PointerEventData evenDataCurPosition = new PointerEventData(EventSystem.current);
        evenDataCurPosition.position = pos;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(evenDataCurPosition, results);
        return results.Count > 0;
    }
}
