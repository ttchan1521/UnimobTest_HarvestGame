using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _backDropButton;

    protected virtual void Start()
    {
        _backDropButton.onClick.AddListener(Hide);
    }

    public void SetParentAndPosition(Transform parent, Vector2 pivotPoint)
    {
        transform.SetParent(parent);
        FitToParent();
        _panel.transform.localPosition = pivotPoint;
    }

    public void Show()
    {
        _panel.SetActive(true);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        _panel.SetActive(false);
        gameObject.SetActive(false);

        ObjectPoolManager.Unspawn(gameObject);
    }

    private void FitToParent()
    {
        transform.localScale = Vector3.one;
        RectTransform rectTransform = GetComponent<RectTransform>();

        // Set anchor full stretch
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;

        // Reset offset để fill parent
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }
}
