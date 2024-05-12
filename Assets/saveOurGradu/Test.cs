using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Firebase.Storage;
using Firebase;
using UnityEngine.Networking;
public class Test : MonoBehaviour
{
    public Material targetMaterial;
    //public string ImagePath;

    FirebaseStorage storage;
    StorageReference storageReference;

    public void DownImage()
    {
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://graduation-5bbb7.appspot.com");
        LoadImage("base/plz.jpg", "base");
        LoadImage("normal/plz_normal.jpg", "normal");
    }
    public void LoadImage(string path, string mapType)
    {

        storageReference.Child(path).GetDownloadUrlAsync().ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Failed to get download URL: " + task.Exception);
                return;
            }
           
            Uri imageUrl = task.Result;
            StartCoroutine(DownloadImageCoroutine(imageUrl, mapType));
        });
    }

    private IEnumerator DownloadImageCoroutine(Uri imageUrl, string mapType)
    {
        using (var request = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            Debug.LogError("Failed to get download URL: " + imageUrl);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
                Debug.LogError("Failed to download image: " + request.error);
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(request);
                if (mapType.Equals("base"))
                    targetMaterial.SetTexture("_BaseMap", texture);
                else if (mapType.Equals("normal"))
                {
                    targetMaterial.EnableKeyword("_NORMALMAP");
                    targetMaterial.SetTexture("_BumpMap", texture);
                    
                }
            }

        }
    }
}
