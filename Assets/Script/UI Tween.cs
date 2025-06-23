using DG.Tweening;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UITween : MonoBehaviour
{
    [Header("Tween Settings")]
    [SerializeField] private float scaleUpDuration = 0.5f;
    [SerializeField] private float scaleDownDuration = 0.5f;
    [SerializeField] private Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f);
    [SerializeField] private Vector3 targetPosition = new Vector3(1.2f, 1.2f, 1.2f);
    [SerializeField] private float targetWidth;
    [SerializeField] private Ease easeType = Ease.InOutQuad;

    private RectTransform rectTransform;
    private Vector3 originalScale;
    private Vector3 originalTransform;
    private float originalWidth;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
        originalTransform = rectTransform.localPosition;
        originalWidth = rectTransform.sizeDelta.x;
    }

    public void StartTweenScale()
    {
        rectTransform.DOScale(targetScale, scaleUpDuration).SetEase(easeType);
    }

    public void StopTweenScale()
    {
        rectTransform.DOScale(originalScale, scaleDownDuration).SetEase(easeType);
    }

    public void StartTweenSlide()
    {
        rectTransform.DOAnchorPos(targetPosition, scaleUpDuration).SetEase(easeType);
    }

    public void StopTweenSlide()
    {
        rectTransform.DOAnchorPos(originalTransform, scaleDownDuration).SetEase(easeType);
    }

    public void StartTweenExpand()
    {
        rectTransform.DOSizeDelta(new Vector2(targetWidth, rectTransform.sizeDelta.y), scaleUpDuration);
    }

    public void ResetWidth()
    {
        rectTransform.DOSizeDelta(new Vector2(originalWidth, rectTransform.sizeDelta.y), scaleDownDuration);
    }
}