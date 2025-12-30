
using UnityEngine;

public static class UIExtension
{
    public static Vector3 GetPositionFromWorldPoint(Vector3 worldPosition, Canvas canvas)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            screenPos,
            canvas.worldCamera,
            out Vector2 canvasPos
        );

        return canvasPos;
    }

    public static string FormatMoney(int amount)
    {
        if (amount >= 1000000000)
            return (amount / 1000000000f).ToString("0.0") + "B";
        if (amount >= 1000000)
            return (amount / 1000000f).ToString("0.0") + "M";
        if (amount >= 10000)
            return (amount / 1000f).ToString("0.0") + "K";
        return amount.ToString();
    }
}
