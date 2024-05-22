using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObjectController : MonoBehaviour
{
    private List<GameObject> placedObjects = new List<GameObject>(); // 생성된 오브젝트들을 저장하는 리스트

    public void AddPlacedObject(GameObject placedObject)
    {
        // 생성된 오브젝트를 리스트에 추가
        placedObjects.Add(placedObject);
    }

    public void RemoveLastPlacedObject()
    {
        if (placedObjects.Count > 0)
        {
            int lastIndex = placedObjects.Count - 1;
            GameObject lastPlacedObject = placedObjects[lastIndex];
            Destroy(lastPlacedObject);
            placedObjects.RemoveAt(lastIndex);
        }
    }
}
