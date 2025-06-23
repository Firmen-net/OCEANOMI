using UnityEngine;
using UnityEngine.UI;

public class DisableButtonOnEnable : MonoBehaviour
{
    public Button btn;

    private void OnEnable()
    {
        btn.interactable = false;
    }

    private void OnDisable()
    {
        btn.interactable = true;
    }
}