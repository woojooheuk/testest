using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Urlimage : MonoBehaviour
{
    public static List<string> ImageUrl;
    public static List<string> LinkUrl;
    public GameObject prefabs;
    public RectTransform contentTransform;
    public static void getUrl(List<string> url,List<string> link)
    {
        ImageUrl = url;
        LinkUrl = link;
    }
    

    public void Startads()
    {
        // 시작할 때 모든 텍스처를 로드
        for (int i = 0; i < ImageUrl.Count-1; i++)
        {
            StartCoroutine(GetTextureAndCreatePrefab(ImageUrl[i+1], LinkUrl[i+1]));
        }
    }

    IEnumerator GetTextureAndCreatePrefab(string url, string link)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            // 프리팹 생성 및 설정
            GameObject rawImageObj = Instantiate(prefabs, contentTransform);
            RawImage rawImage = rawImageObj.GetComponentInChildren<RawImage>();
            rawImage.texture = myTexture;
            Button button = rawImageObj.GetComponentInChildren<Button>();

            if (button == null)
            {
                button = rawImageObj.AddComponent<Button>();
            }
            button.onClick.AddListener(() => OpenUrl(link));
        }
    }

    void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }
}