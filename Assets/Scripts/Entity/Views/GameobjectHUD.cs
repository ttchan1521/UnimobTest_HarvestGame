using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectHUD : MonoBehaviour
{
    public void SetParentAndPosition(Transform parent, Vector3 offset)
    {
        transform.SetParent(parent);
        transform.localPosition = offset;
        transform.localScale = Vector3.one;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ObjectPoolManager.Unspawn(gameObject);
    }
}
