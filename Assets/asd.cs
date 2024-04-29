using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System;
public class asd : MonoBehaviour
{
    public string pythonScriptPath = "Assets/omnidata-main/omnidata_tools/torch/demo.py"; // Python 스크립트 파일의 경로
    public string imgPath = "Assets/Images/Plz.png"; // img_path 인수
    public string outputPath = "Assets/omnidata-main/omnidata_tools/torch/assets/"; // output_path 인수

    public void RunPythonDemo()
    {
        // 터미널 명령 준비
        string command = $"python {pythonScriptPath} --task normal --img_path {imgPath} --output_path {outputPath}";
        // 프로세스 생성
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "cmd.exe"; // Windows 운영 체제를 사용하는 경우
        start.Arguments = command;
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        // 프로세스 시작
        using (Process process = Process.Start(start))
        {
            using(StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                UnityEngine.Debug.Log(result);
            }
        }

    }

}

//이 느낌으로 그냥 파이썬에서 생성하고 유니티에서 인식시키는 거도 될듯
/*
 * using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    public Material imageMaterial; // 이미지를 표시할 Material

    void Start()
    {
        LoadImage();
    }

    void LoadImage()
    {
        string imagePath = "file://" + Application.dataPath + "/test_image.png"; // 이미지 파일 경로
        StartCoroutine(LoadTexture(imagePath));
    }

    IEnumerator LoadTexture(string imagePath)
    {
        WWW www = new WWW(imagePath);
        yield return www;

        Texture2D texture = www.texture;

        if (texture != null)
        {
            imageMaterial.mainTexture = texture;
        }
        else
        {
            Debug.LogError("이미지를 불러올 수 없습니다.");
        }
    }
}
 */