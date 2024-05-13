using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using NativeGalleryNamespace;
using Firebase.Storage;
using Firebase;
public class LoadGallery : MonoBehaviour
{
    public RawImage photoDisplay;

    FirebaseStorage storage;
    /*
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
                storage = FirebaseStorage.DefaultInstance;
            else
                Debug.LogError("Failed to initialize Firebase Storage");
        });
    }*/

    public void GetPhotoFromGallery()
    {
        storage = FirebaseStorage.DefaultInstance;
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                StartCoroutine(LoadImage(path));
            }

        });
    }

    private IEnumerator LoadImage(string path)
    {
        byte[] imageBytes = File.ReadAllBytes(path);

        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imageBytes);

        photoDisplay.texture = texture;

        yield return StartCoroutine(UploadImageToFirebase(path));
    }
 
    private IEnumerator UploadImageToFirebase(string imagePath)
    {
        if(storage == null)
        {
            Debug.LogError("Firebase Storage is not initialize");
            yield break;
        }

        string imageName = Path.GetFileName(imagePath);

        byte[] imageBytes = File.ReadAllBytes(imagePath);

        StorageReference imageRef = storage.GetReference("base").Child(imageName);

        
        var uploadTask = imageRef.PutBytesAsync(imageBytes);

        yield return new WaitUntil(() => uploadTask.IsCompleted);

        if (uploadTask.Exception != null)
            Debug.LogError("Failed to upload image: " + uploadTask.Exception);
        else
            Debug.Log("Image uploaded complete");

        MaterialMaker.getName(imageName);
        Request.getName(imageName);
    }
}
