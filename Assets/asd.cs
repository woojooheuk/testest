using UnityEngine;
using System.Diagnostics;

public class asd : MonoBehaviour
{
    public string pythonScriptPath = "Assets/omnidata-main/omnidata_tools/torch/demo.py"; // Python 스크립트 파일의 경로
    public string task = "normal"; // task 인수
    public string imgPath = "Assets/Images/asd_rgb.png"; // img_path 인수
    public string outputPath = "Assets/omnidata-main/omnidata_tools/torch/assets/"; // output_path 인수
    
    public void RunPythonDemo()
    {
        // 터미널 명령 준비
        string command = $"python {pythonScriptPath} --task {task} --img_path {imgPath} --output_path {outputPath}";
        UnityEngine.Debug.Log("1");
        // 프로세스 생성
        Process process = new Process();
        UnityEngine.Debug.Log("2");
        process.StartInfo.FileName = "cmd.exe"; // Windows 운영 체제를 사용하는 경우
        UnityEngine.Debug.Log("3");
        process.StartInfo.Arguments = command;
        UnityEngine.Debug.Log("4");
        process.StartInfo.UseShellExecute = false;
        UnityEngine.Debug.Log("5");
        process.StartInfo.RedirectStandardOutput = true;
        UnityEngine.Debug.Log("6");
        // 프로세스 시작
        process.Start();
        UnityEngine.Debug.Log("7");
        // 실행 결과 읽기
        string result = process.StandardOutput.ReadToEnd();
        UnityEngine.Debug.Log("8");
        process.WaitForExit();
        UnityEngine.Debug.Log("9");

        // 실행 결과 출력
        UnityEngine.Debug.Log(result);
    }
}