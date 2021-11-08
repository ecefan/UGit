using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int X_Start;
    public int Y_Start;
    public int x_space_between_item;
    public int y_space_between_item;
    public int number_columns;

    Dictionary<InvenorySlot, GameObject> itemsDisplay = new Dictionary<InvenorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void CreateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");

            itemsDisplay.Add(inventory.Container[i], obj);

        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_Start +( x_space_between_item * (i % number_columns)), Y_Start + ((-y_space_between_item * (i % number_columns))), 0f);
    }

    private void UpdateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplay.ContainsKey(inventory.Container[i]))
            {
                itemsDisplay[inventory.Container[i]].GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplay.Add(inventory.Container[i], obj);
            }
        }
    }
}
