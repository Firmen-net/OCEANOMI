using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NextQuestion : MonoBehaviour
{
    public GameObject next;
    public Image img;

    private void Start()
    {
    }

    public void Next()
    {
        StartCoroutine(delayNext());
    }

    private IEnumerator delayNext()
    {
        yield return new WaitForSeconds(3f);
        transform.gameObject.SetActive(false);
        next.SetActive(true);
        img.color = Color.yellow;
    }
}