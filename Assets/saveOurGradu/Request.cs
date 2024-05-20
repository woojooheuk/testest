using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using Firebase;
using Firebase.Storage;
using System.Net;
public class Request : MonoBehaviour {

    private string serverUrl = "http://124.54.77.48:80";
    public static string imagePath;

    FirebaseStorage storage;
    StorageReference storageReference;

    public static void getName(string name)
    {
        imagePath =  name;
    }
    public void Startasdsad()
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        StartCoroutine(DownloadImage("/process_image"));
    }

    public void startRec()
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        StartCoroutine(DownloadImage("/recommend"));
    }
    IEnumerator DownloadImage(string def)
    {
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReference("base/"+imagePath);
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

            StartCoroutine(UploadAndDeleteImage(def, imageBytes));
        }
    }
    //자준이 필요한 거 내가 갤러리에서 선택한 이미지
    //로드 갤러리. 이미지 업로드
    //리퀘스트 = 채호 서버에 이미지 보내고 요청
    //리퀘스트 버튼을 둘로. 함수 나눠서 지정.
    //csv 요청 버튼 누르면 이미지 다운 및 서버에 보내
    //눌리는 버튼에 따라 /process_image 인지 /recommend인지 정해
    IEnumerator UploadAndDeleteImage(string def, byte[] imageBytes)
    {
        WWWForm form = new WWWForm();

        form.AddBinaryData("image", imageBytes, imagePath);

        UnityWebRequest www = UnityWebRequest.Post(serverUrl+def, form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to upload image: " + www.error);
            Debug.LogError("Failed to upload image: " + www.result);
        }
        else
        {
            Debug.Log("Image uploaded successfully");

            if (!www.downloadHandler.text.Contains("Failed to process the image"))
            {
                Debug.Log("delete complete");
            }
        }
    }
}