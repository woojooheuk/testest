using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class MaterialMaker : MonoBehaviour
{
    public Material originalMat;
    public Texture2D baseTexture;
    public Texture2D normalTexture;
    public string matPath = "Assets/Materials/";
    // Start is called before the first frame update
    void Start()
    {
        MakeMat();
    }

    void Setting()
    {

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
        string path = "Assets/Resources/copied.mat";
        AssetDatabase.CreateAsset(copiedMat, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }
}
