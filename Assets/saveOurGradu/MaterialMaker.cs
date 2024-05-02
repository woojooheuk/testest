using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class MaterialMaker : MonoBehaviour
{
    private Material originalMat;
    private Texture2D baseTexture;
    private Texture2D normalTexture;

    // Start is called before the first frame update
    public void Start()
    {
        Setting();
    }

    void Setting()
    {
        originalMat = Resources.Load<Material>("Materials/ChangeLightMaterial");
        baseTexture = Resources.Load<Texture2D>("Images/KakaoTalk_20240502_154951629");
        normalTexture = Resources.Load<Texture2D>("Images/KakaoTalk_20240502_154951629_normal");
        MakeMat();
    }

    void MakeMat()
    {
        if (originalMat == null)
        {
            Debug.LogError("Original material is not assigned.");
            return;
        }

        Material copiedMat = new Material(originalMat);

        copiedMat.name = "RelightExample";

        if (baseTexture != null)
            copiedMat.SetTexture("_BaseMap", baseTexture);

        if (normalTexture != null)
        {
            copiedMat.SetTexture("_BumpMap", normalTexture);
            copiedMat.EnableKeyword("_NORMALMAP");
        }
        string path = "Assets/Resources/Materials/copied.mat";
        AssetDatabase.CreateAsset(copiedMat, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }

}

