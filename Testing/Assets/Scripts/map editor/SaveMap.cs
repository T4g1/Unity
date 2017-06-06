using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMap : MonoBehaviour
{
    public void OnSave()
    {
#if UNITY_EDITOR
        for (int i=0; i< transform.childCount; i++)
        {
            GameObject chunk = transform.GetChild(i).gameObject;

            MeshFilter meshFilter = chunk.GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = chunk.GetComponent<MeshRenderer>();

            string path = "Assets/Terrains/" + meshFilter.name + ".asset";

            UnityEditor.AssetDatabase.CreateAsset(meshFilter.mesh, path);
            UnityEditor.AssetDatabase.AddObjectToAsset(meshRenderer.material, path);
        }

        UnityEditor.AssetDatabase.SaveAssets();
#endif
    }
}