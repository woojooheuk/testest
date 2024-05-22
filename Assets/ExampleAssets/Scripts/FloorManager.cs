using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FloorManager : MonoBehaviour
{
    [SerializeField] ARRaycastManager arRaycastManager;
    [SerializeField] ARPlaneManager arPlaneManager; // ARPlaneManager 추가

    private bool floorDetectionEnabled = true;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("FloorButton"))
                    {
                        ToggleFloorDetection();
                    }
                }
            }
        }
    }

    public void ToggleFloorDetection()
    {
        floorDetectionEnabled = !floorDetectionEnabled;

        if (floorDetectionEnabled)
        {
            arRaycastManager.enabled = true;
            arPlaneManager.enabled = true; // 바닥 표시 활성화
        }
        else
        {
            arRaycastManager.enabled = false;
            arPlaneManager.enabled = false; // 바닥 표시 비활성화
        }
    }
}
