using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void ReceivePath(string path)
    {
        Debug.Log("Received complete: " + path);
    }
}
