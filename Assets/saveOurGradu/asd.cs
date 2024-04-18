using UnityEngine;
using System.Diagnostics;

public class asd : MonoBehaviour
{
    public string pythonScriptPath = "C:/Users/10Group/Documents/GitHub/testest/Assets/omnidata-main/omnidata_tools/torch/demo.py"; // Python 스크립트 파일의 경로
    public string task = "normal"; // task 인수
    public string imgPath = "C:/Users/10Group/Documents/GitHub/testest/Assets/Images/Plz.jpeg"; // img_path 인수
    public string outputPath = "C:/Users/10Group/Documents/GitHub/testest/Assets/Images"; // output_path 인수

    public void RunPythonDemo()
    {
        // 터미널 명령 준비
        string command = $"python {pythonScriptPath} --task {task} --img_path {imgPath} --output_path {outputPath}";

        // 프로세스 생성
        Process process = new Process();
       
        process.StartInfo.FileName = "cmd.exe"; // Windows 운영 체제를 사용하는 경우
        process.StartInfo.Arguments = $"-c \"{command}\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;

        // 프로세스 시작
        process.Start();

        // 실행 결과 읽기
        string result = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        // 실행 결과 출력
        UnityEngine.Debug.Log(result);
    }
}