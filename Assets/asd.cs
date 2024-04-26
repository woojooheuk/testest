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
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe"; // Windows 운영 체제를 사용하는 경우
        process.StartInfo.Arguments = command;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        // 프로세스 시작
        process.Start();
        // 실행 결과 읽기
        string result = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        // 실행 결과 출력

        UnityEngine.Debug.Log(result);

        SendAndReceiveImage();
    }

    void SendAndReceiveImage()
    {
        try
        {
            string serverIP = "127.0.0.1";
            int port = 80;
            /* 이미지 전송
            using (TcpClient client = new TcpClient(serverIP, port))
            {
                using(NetworkStream stream = client.GetStream())
                {
                    byte[] imgData = File.ReadAllBytes(Path.Combine(outputPath, "output_normal.png"));

                    stream.Write(BitConverter.GetBytes(imgData.Length), 0, 4);

                    stream.Write(imgData, 0, imgData.Length);
                }
            }
            https://artsung410.tistory.com/100
        */
            //이미지 수신
            using (TcpClient client = new TcpClient(serverIP, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] imgSizeBytes = new byte[4];
                    stream.Read(imgSizeBytes, 0, 4);
                    int imSize = BitConverter.ToInt32(imgSizeBytes, 0);

                    byte[] imgData = new byte[imSize];
                    stream.Read(imgData, 0, imSize);

                    File.WriteAllBytes(Path.Combine(outputPath, "received_image.png"), imgData);
                }
            }
            UnityEngine.Debug.Log("이미지 수신 완료");
        }
        catch(System.Exception e)
        {
            UnityEngine.Debug.Log($"에러:{e.Message}");
        }    
    }
}