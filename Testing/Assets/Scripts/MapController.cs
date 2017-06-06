using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public Material terrainMaterial;

    public TextureData textureData;
    public TerrainData terrainData;

    private void Awake()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                GameObject meshObject = new GameObject();

                MeshRenderer meshRenderer = meshObject.AddComponent<MeshRenderer>();
                MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
                MeshCollider meshCollider = meshObject.AddComponent<MeshCollider>();

                string name = "Terrain Chunk " + x + " " + y;

                Mesh mesh = Resources.Load(name) as Mesh;

                meshRenderer.material = terrainMaterial;
                meshFilter.mesh = mesh;
                meshCollider.sharedMesh = mesh;

                meshObject.name = name;
                meshObject.transform.parent = transform;

                meshObject.transform.SetPositionAndRotation(
                    new Vector3(x * 238, 0, y * 238),
                    Quaternion.Euler(0f, 0f, 0f)
                );
            }
        }

        textureData.ApplyToMaterial(terrainMaterial);
        textureData.UpdateMeshHeights(terrainMaterial, terrainData.minHeight, terrainData.maxHeight);
    }
}