using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGridNavigator : MonoBehaviour
{
    private GameObject[] _itemButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnItemClick(GameObject clearButton)
    {
        _itemButtons = GameObject.FindGameObjectsWithTag("ItemButton");
        foreach (GameObject item in _itemButtons)
        {
            item.GetComponent<UiItem>().clearButton.gameObject.SetActive(false);
        }
        clearButton.SetActive(true);
    }

}
