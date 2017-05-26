using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueListController : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Image onGoingImage;
    public Slider progress;
    //public Transform queued;

    private GameObject selected;
    private QueuedItem onGoingItem;

    private List<GameObject> buttons;

    private void Awake()
    {
        buttons = new List<GameObject>();

        ClearSelection();
    }

    private void Update()
    {
        // Nothing to display
        if (selected == null)
        {
            return;
        }

        ClearDisplay();
        DisplayQueue();
    }


    /**
     * Set displayed item and display queue
     * */
    public void DisplayQueueFor(GameObject obj)
    {
        BasicController ctrl = obj.GetComponent<BasicController>();
        if (ctrl == null)
        {
            return;
        }

        ClearSelection();

        selected = obj;

        DisplayQueue();
    }

    /**
     * Display the full queue
     * */
    public void DisplayQueue()
    {
        BasicController controller = selected.GetComponent<BasicController>();
        
        onGoingItem = null;

        RectTransform buttonTransform = buttonPrefab.GetComponent<RectTransform>();

        RectTransform transform = gameObject.GetComponent<RectTransform>();
        int maxItemCountX = Mathf.FloorToInt(-transform.sizeDelta.x / (buttonTransform.sizeDelta.x + 7));

        foreach (QueuedItem item in controller.workQueue)
        {
            GameObject obj = item.obj;

            if (onGoingItem == null)
            {
                onGoingItem = item;
                onGoingImage.sprite = item.obj.GetComponent<Image>().sprite;
            }
            else
            {
                GameObject button = Instantiate(buttonPrefab);
                button.transform.SetParent(gameObject.transform);

                button.GetComponentInChildren<Text>().text = obj.name;

                Image icon = obj.GetComponent<Image>();
                if (icon != null)
                {
                    button.GetComponent<Image>().sprite = icon.sprite;
                }

                float x = (buttonTransform.sizeDelta.x + 7) * (buttons.Count % maxItemCountX);
                float y = (buttonTransform.sizeDelta.y + 7) * -(buttons.Count / maxItemCountX);

                buttonTransform.anchoredPosition = new Vector3(transform.position.x + x, transform.position.y + y);

                buttons.Add(button);
            }
        }
    }

    public void ClearSelection()
    {
        selected = null;
        onGoingItem = null;

        ClearDisplay();
    }

    private void ClearDisplay()
    {
        onGoingImage.sprite = null;

        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }

        buttons.Clear();
    }
}
