using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour
{
    public List<Button> button = new();

    private void OnEnable()
    {
        foreach (var item in button)
        {
            item.interactable = true;
        }
    }

    public void SetButtonNotInteractable()
    {
        foreach (var item in button)
        {
            item.interactable = false;
        }
    }
}