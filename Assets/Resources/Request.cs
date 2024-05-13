using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using Firebase;
using Firebase.Storage;
public class Request : MonoBehaviour
{
    public string serverUrl = "http://127.0.0.1:5000/process_image";
    public static string imagePath;

    FirebaseStorage storage;
    StorageReference storageReference;

    public static void getName(string name)
    {
        imagePath = "base/" + name;
    }
    public void Startasdsad()
    {
            StartCoroutine(DownloadImage());
    }

    IEnumerator DownloadImage()
    {
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReference(imagePath);
        var downloadTask = storageReference.GetDownloadUrlAsync();
        yield return new WaitUntil(() => downloadTask.IsCompleted);

        if (downloadTask.Exception != null)
        {
            Debug.LogError("Failed to download image: " + downloadTask.Exception);
            yield break;
        }

        string imageUrl = downloadTask.Result.ToString();

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to download image: " + www.error);
                yield break;
            }

            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            byte[] imageBytes = texture.EncodeToPNG();

            StartCoroutine(UploadAndDeleteImage(imageBytes));
        }
    }
    IEnumerator UploadAndDeleteImage(byte[] imageBytes)
    {
        WWWForm form = new WWWForm();

        form.AddBinaryData("image", imageBytes, "image.jpg", "image/jpeg");

        UnityWebRequest www = UnityWebRequest.Post(serverUrl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
            Debug.LogError("Failed to upload image: " + www.error);
        else
        {
            Debug.Log("Image uploaded successfully");
            Debug.Log("Response: " + www.downloadHandler.text);

            if(!www.downloadHandler.text.Contains("Failed to process the image"))
            {
                Debug.Log("deleted complete");
            }
        }
    }
}