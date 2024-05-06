using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
public class PathToTxt : MonoBehaviour
{
    //용호 측에서 이 스크립트를 먼저 실행하여 스크린샷 이미지 위치를 넘겨줘야함
    private string TxtPath = "Assets/Resources/TxtPath.txt";

    public void TxtMaker()
    {
        CreateTextFile(TxtPath);
    }

    void CreateTextFile(string filePath)
    {
        //여기도 갤러리 정보를 받든 뭘 하든 수정해야함
        File.WriteAllText(filePath, "Images/KakaoTalk_20240502_154951629");
        AssetDatabase.Refresh();
    }

}
