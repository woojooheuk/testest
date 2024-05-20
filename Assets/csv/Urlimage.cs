using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Urlimage : MonoBehaviour
{
    public RawImage rawImage;
    void Start()
    {
        List<Dictionary<string,object>> data = CSVReader.Read("test_list");
        StartCoroutine(GetTexture(url));
    }
    public string url = "data[i][\"image\"].ToString()";
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetTexture(string url)
    {

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            rawImage.texture = myTexture;
        }
    }
}

