using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Storage;
using UnityEngine.UI;
public class firebaseimage : MonoBehaviour
{
    public RawImage rawImage;
    FirebaseStorage storage;
    // Start is called before the first frame update
    void Start()
    {
        // Firebase �ʱ�ȭ
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                // Firebase Storage �ν��Ͻ� �ʱ�ȭ
                storage = FirebaseStorage.DefaultInstance;
                Debug.Log("Firebase initialized successfully.");

                GetImageURL();
            }
            else
            {
                Debug.LogError("Failed to initialize Firebase: " + task.Exception);
            }
        });
        
    }
    public void GetImageURL()
    {
        if (storage == null)
        {
            Debug.LogError("Firebase Storage is not initialized.");
            return;
        }

        // �̹����� ���� ��������
        StorageReference imageRef = storage.GetReferenceFromUrl("gs://graduation-5bbb7.appspot.com/qwe (1).jpeg");

        // �̹����� �ٿ�ε� URL ��������
        imageRef.GetDownloadUrlAsync().ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Failed to get download URL: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                string imageUrl = task.Result.ToString();
                Debug.Log("Image URL: " + imageUrl);

                // �ٿ�ε��� �̹����� Raw Image�� ����
                LoadImage(imageUrl);
            }
        });
    }

    public void LoadImage(string imageUrl)
    {
        StartCoroutine(LoadImageCoroutine(imageUrl));
    }

    IEnumerator LoadImageCoroutine(string imageUrl)
    {
        // �̹��� �ٿ�ε�
        using (WWW www = new WWW(imageUrl))
        {
            yield return www;

            if (www.error != null)
            {
                Debug.LogError("Failed to download image: " + www.error);
            }
            else
            {
                // �ؽ�ó ����
                Texture2D texture = new Texture2D(2, 2);
                www.LoadImageIntoTexture(texture);

                // Raw Image�� ����
                rawImage.texture = texture;
            }
        }
    }
}