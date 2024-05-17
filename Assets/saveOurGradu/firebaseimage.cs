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
        // Firebase ÃÊ±âÈ­
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                storage = FirebaseStorage.DefaultInstance;
                Debug.Log("Firebase initialized successfully.");

            }
            else
            {
                Debug.LogError("Failed to initialize Firebase: " + task.Exception);
            }
        });
        
    }
}