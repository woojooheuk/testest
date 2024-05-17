using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using Firebase.Storage;
using Firebase;
public class MaterialMaker : MonoBehaviour
{
    public Material originalMat;

    FirebaseStorage storage;
    StorageReference storageReference;
    private static string imagename;
    public static void getName(string name)
    {
        imagename = name;
    }
    /*
    private void Start()
    {
        // Firebase 초기화
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                
                Debug.Log("Firebase initialized successfully.");

                // Firebase Storage에서 이미지 다운로드 및 메테리얼에 적용
                LoadImages();
            }
            else
            {
                Debug.LogError("Failed to initialize Firebase.");
            }
        });
    }
    */
    public void LoadImages()
    {
        storage = FirebaseStorage.DefaultInstance;
        
        Debug.Log(imagename);
        DownloadImage("base/"+imagename, "baseMap");
        DownloadImage("normal/"+imagename, "normalMap");
    }

    void DownloadImage(string imagePath, string mapType)
    {
        storageReference = storage.GetReference(imagePath);
        Debug.Log(storageReference);
        storageReference.GetDownloadUrlAsync().ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Failed to get download URL: " + task.Exception);
                return;
            }

            Uri imageUrl = task.Result;

            // 이미지를 다운로드하고 메테리얼에 적용
            if (imageUrl == null)
            {
                Debug.LogError("Download URL is null.");
                return;
            }
            StartCoroutine(LoadImageFromUrl(imageUrl, mapType));
        });
    }

    IEnumerator LoadImageFromUrl(Uri url, string mapType)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to download image: " + www.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);

                // 메테리얼에 텍스쳐를 적용
                if (mapType == "baseMap")
                {
                    originalMat.SetTexture("_BaseMap", texture);
                }
                else if (mapType == "normalMap")
                {
                    originalMat.EnableKeyword("_NORMALMAP");
                    originalMat.SetTexture("_BumpMap", texture);
                    
                }
            }
        }
    }
}