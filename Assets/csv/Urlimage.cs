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
    public string url = "data[i][\"image\"].ToString()";
    public static List<string> ImageUrl;
    public static List<string> LinkUrl;

    public static void getUrl(List<string> url,List<string> link)
    {
        ImageUrl = url;
        LinkUrl = link;
    }
    public void Startfdhj()
    {
        
        List<Dictionary<string,object>> data = CSVReader.Read("test_list2");
        StartCoroutine(GetTexture(url));
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

