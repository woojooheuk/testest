using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObject : MonoBehaviour
{
    private bool isSelected;

    private MeshRenderer meshRenderer;
    private Color originColor;

    public bool Selected
    {
        get
        {
            return this.isSelected;
        }

        set
        {
            isSelected = value;
            UpdateMaterialColor();
        }
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (!meshRenderer)
        {
            meshRenderer = this.gameObject.AddComponent<MeshRenderer>();
        }

        originColor = meshRenderer.material.color;
    }

    private void UpdateMaterialColor()
    {
        if (isSelected)
        {
            meshRenderer.material.color = Color.gray;
        }

        else
        {
            meshRenderer.material.color = originColor;
        }
    }


}
