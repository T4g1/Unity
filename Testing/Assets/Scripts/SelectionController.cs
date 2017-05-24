using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public Collider terrainCollider;
    public GameObject selectionOutliner;

    private List<GameObject> selectedList;
    private Vector2 firstPoint;
    private Vector2 secondPoint;
    private bool dragSelection;

    private RectTransform selectionOutlinerPosition;
    private Image selectionOutlinerImage;

    private void Awake()
    {
        selectedList = new List<GameObject>();

        selectionOutlinerPosition = selectionOutliner.GetComponent<RectTransform>();
        selectionOutlinerImage = selectionOutliner.GetComponent<Image>();
    }

    private void SelectObject(GameObject obj)
    {
        if (selectedList.Contains(obj))
        {
            return;
        }

            selectedList.Add(obj);

        Renderer[] rs = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.green;
            r.material = m;
        }
    }

    private void DeselectObject(GameObject obj)
    {
        Renderer[] rs = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }

        selectedList.Remove(obj);
    }

    private void ClearSelection()
    {
        while (selectedList.Count > 0)
        {
            DeselectObject(selectedList[0]);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        secondPoint = eventData.position;

        Vector3 lowerLeft = new Vector2(firstPoint.x, firstPoint.y);
        Vector3 upperRight = new Vector2(secondPoint.x, secondPoint.y);

        if (firstPoint.x > secondPoint.x)
        {
            lowerLeft.x = secondPoint.x;
            upperRight.x = firstPoint.x;
        }

        if (firstPoint.y > secondPoint.y)
        {
            lowerLeft.y = secondPoint.y;
            upperRight.y = firstPoint.y;
        }

        Rect screenRectangle = new Rect(
            lowerLeft.x,
            lowerLeft.y,
            upperRight.x - lowerLeft.x,
            upperRight.y - lowerLeft.y
        );

        selectionOutlinerPosition.position = new Vector2(screenRectangle.x, screenRectangle.y);
        selectionOutlinerPosition.sizeDelta = new Vector2(screenRectangle.width, screenRectangle.height);

        selectionOutlinerImage.enabled = true;

        GameObject[] selectableUnits = GameObject.FindGameObjectsWithTag("Selectable");

        foreach (GameObject selectable in selectableUnits)
        {
            Vector3 screenSpacePosition = Camera.main.WorldToScreenPoint(selectable.transform.position);

            if (screenRectangle.Contains(screenSpacePosition))
            {
                SelectObject(selectable);
            }
            else
            {
                DeselectObject(selectable);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        selectionOutlinerImage.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            firstPoint = eventData.position;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
                {
                    ClearSelection();
                }

                GameObject obj = hit.transform.gameObject;
                if (obj.CompareTag("Selectable"))
                {
                    SelectObject(obj);
                }
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (terrainCollider.Raycast(ray, out hit, Mathf.Infinity))
            {
                foreach (GameObject selected in selectedList)
                {
                    IActionable obj = selected.GetComponent<IActionable>();
                    if (obj == null)
                    {
                        continue;
                    }

                    obj.OnSecondAction(hit.point);
                }
            }
        }
    }
}
