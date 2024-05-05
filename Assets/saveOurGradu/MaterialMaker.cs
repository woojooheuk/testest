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
    private void Start()
    {
        Setting();
    }
    public void Setting()
    {
        originalMat = Resources.Load<Material>("Materials/ChangeLightMaterial");
        //밑에 이미지 주소들 변수화 시킬것
        baseTexture = Resources.Load<Texture2D>("Images/KakaoTalk_20240502_154951629");
        normalTexture = Resources.Load<Texture2D>("Images/KakaoTalk_20240502_154951629_normal");
        ChangeTextureShapeNormalmap(normalTexture);
        
        MakeMat(baseTexture, normalTexture);
    }

    void ChangeTextureShapeNormalmap(Texture2D texture)
    {
        string assetPath = AssetDatabase.GetAssetPath(texture);
        if (!string.IsNullOrEmpty(assetPath))
        {
            TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            if (importer != null)
            {
                importer.textureType = TextureImporterType.NormalMap;
                importer.SaveAndReimport();
            }
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
        string path = "Assets/Resources/Materials/copied.mat";
        AssetDatabase.CreateAsset(copiedMat, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }

}

