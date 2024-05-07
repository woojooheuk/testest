using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
public class PathToTxt : MonoBehaviour
{
    //��ȣ ������ �� ��ũ��Ʈ�� ���� �����Ͽ� ��ũ���� �̹��� ��ġ�� �Ѱ������
    private string TxtPath = "Assets/Resources/TxtPath.txt";

    public void TxtMaker()
    {
        CreateTextFile(TxtPath);
    }

    void CreateTextFile(string filePath)
    {
        //���⵵ ������ ������ �޵� �� �ϵ� �����ؾ���
        File.WriteAllText(filePath, "Images/KakaoTalk_20240507_115718762");
        AssetDatabase.Refresh();
    }

}
