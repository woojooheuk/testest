using Firebase.Storage;
using Firebase;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Firebase.Extensions;
using System.Threading.Tasks;
using System.Text;

public class test_url : MonoBehaviour
{
    private FirebaseStorage storage;
    public static string imageName;
    //���̽� ���� �� �� �����ؾ��ϴ� �ڵ�
    public static void getName(string name)
    {
        imageName = name;
    }

    public void ReadCSV()
    {
        storage = FirebaseStorage.DefaultInstance;

        ReadCSVFromStorage();
    }

    void ReadCSVFromStorage()
    {
        StorageReference csvRef = storage.GetReference("recommend").Child("crack.csv");
        Debug.Log("before");
        csvRef.GetBytesAsync(long.MaxValue).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError(task.Exception.ToString());
            }
            else
            {
                Debug.Log("suc");
                byte[] fileContents = task.Result;
                string csvText = Encoding.UTF8.GetString(fileContents);
                ParseCSV(csvText);
            }
        });
    }

    void ParseCSV(string csvText)
    {
        StringReader reader = new StringReader(csvText);
        string line;
        int i = 0;

        // ������ ������ ���� ����Ʈ ���
        List<string> imgUrl = new List<string>();
        List<string> link = new List<string>();

        while ((line = reader.ReadLine()) != null)
        {
            string[] values = line.Split(',');
            if (values.Length >= 2)
            {
                imgUrl.Add(values[0]);
                link.Add(values[1]);
                i++;
            }
        }

        // ù ��° 20���� �����͸� ���
        for (int j = 1; j < 21; j++)
        {
            Debug.Log($"Image URL: {imgUrl[j]}, Link: {link[j]}, Index: {j + 1}");
        }
    }
}