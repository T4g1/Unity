using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionListController : MonoBehaviour {
    public GameObject buttonPrefab;
    public int maxButtonX;
    public int maxButtonY;

    private List<GameObject> buttons;

    private void Awake()
    {
        buttons = new List<GameObject>();
    }

    public void DisplayActionListFor(GameObject obj)
    {
        ICanBuild builder = obj.GetComponent<ICanBuild>();
        if (builder != null)
        {
            foreach (GameObject building in builder.Buildings)
            {
                AddButton(obj, building);
            }
        }

        ICanTrainUnits trainer = obj.GetComponent<ICanTrainUnits>();
        if (trainer != null)
        {
            foreach (GameObject unit in trainer.TrainableUnits)
            {
                AddButton(obj, unit);
            }
        }

        /*ICanResearch scientist = selected.GetComponent<ICanResearch>();
        if (scientist != null)
        {

        }*/
    }

    public void AddButton(GameObject actor, GameObject obj)
    {
        GameObject button = Instantiate(buttonPrefab);
        button.transform.SetParent(gameObject.transform);

        button.GetComponentInChildren<Text>().text = obj.name;

        Image icon = obj.GetComponent<Image>();
        if (icon != null)
        {
            button.GetComponent<Image>().sprite = icon.sprite;
        }

        RectTransform transform = button.GetComponent<RectTransform>();
        
        float x = transform.sizeDelta.x * (buttons.Count % maxButtonX);
        float y = -transform.sizeDelta.y * (buttons.Count / maxButtonX);

        transform.anchoredPosition = new Vector3(x, y);

        BasicController ctrl = actor.GetComponent<BasicController>();

        Button buttonCtrl = button.GetComponent<Button>();
        buttonCtrl.onClick.AddListener(() => ctrl.AddToQueue(obj));

        buttons.Add(button);
    }

    public void ClearButtons()
    {
        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }

        buttons.Clear();
    }
}
