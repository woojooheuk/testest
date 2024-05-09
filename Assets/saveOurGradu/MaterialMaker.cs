using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MaterialMaker : MonoBehaviour
{
    private Material originalMat;
    private Texture2D baseTexture;
    private Texture2D normalTexture;
    private int set = 0;
    private string TxtPath = "Assets/Resources/TxtPath.txt";

    private void Start()
    {
        Setting();
    }

    public string ReadTextFile()
    {
        string imagePath = File.ReadAllText(TxtPath);
        Debug.Log(imagePath);
        return imagePath;
    }

    public void Setting()
    {
        if (set == 0)
        {
            string ImagePath = ReadTextFile();
            originalMat = Resources.Load<Material>("Materials/ChangeLightMaterial");
            baseTexture = Resources.Load<Texture2D>(ImagePath);
            normalTexture = Resources.Load<Texture2D>(ImagePath + "_normal");
            MakeMat(baseTexture, normalTexture);
        }
    }

    void MakeMat(Texture2D Base, Texture2D Normal)
    {
        if (originalMat == null)
        {
            Debug.LogError("Original material is not assigned.");
            return;
        }

        Material copiedMat = new Material(originalMat);
        copiedMat.name = "RelightExample";

        if (baseTexture != null)
            copiedMat.SetTexture("_BaseMap", Base);

        if (normalTexture != null)
        {
            copiedMat.SetTexture("_BumpMap", Normal);
            copiedMat.EnableKeyword("_NORMALMAP");
        }

        // 임시로 메모리에만 저장
        //GetComponent<Renderer>().material = copiedMat;

        set = 1;
    }
}
