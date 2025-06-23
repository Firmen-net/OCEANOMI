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
    [SerializeField] private Ease easeType = Ease.InOutQuad;

    private RectTransform rectTransform;
    private Vector3 originalScale;
    private Vector3 originalTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
        originalTransform = rectTransform.localPosition;
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
}