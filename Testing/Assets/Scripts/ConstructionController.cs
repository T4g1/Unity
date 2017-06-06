using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Displays preview of building being build
 * Controls building placement according to terrain underneath
 * */
public class ConstructionController : MonoBehaviour
{
    public GameObject temp;
    public Material statusMaterial;

    private GameObject building;

    private void Awake()
    {
        SetBuilding(temp);
    }

    private void Update()
    {
        // Nothing being build
        if (building == null)
        {
            return;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            float x = Mathf.Floor(hit.point.x);
            float z = Mathf.Floor(hit.point.z);

            building.transform.SetPositionAndRotation(
                new Vector3(x, 0f, z),
                Quaternion.identity
            );
        }

        if (Input.GetButton("Fire1"))
        {
            BeginConstruction();
        }
        else if (Input.GetButton("Fire2"))
        {
            Cancel();
        }
    }

    public void SetBuilding(GameObject _building)
    {
        Cancel();

        building = Instantiate(_building, new Vector3(0f, 0f, 0f), Quaternion.identity);

        MeshRenderer meshRenderer = building.GetComponentInChildren<MeshRenderer>();
        meshRenderer.material = statusMaterial;
        meshRenderer.material.color = new Color(0f, 1f, 0.1f, 0.4f);
    }

    public void Cancel()
    {
        if (building != null)
        {
            Destroy(building);
            building = null;
        }
    }

    private void BeginConstruction()
    {
        // TODO

        Cancel();
    }
}