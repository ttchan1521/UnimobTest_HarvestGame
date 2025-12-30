
using UnityEngine;

public abstract class ClickItem : MonoBehaviour
{
    public abstract void OnClick();
}

public class ClickableItem : MonoBehaviour
{
    [SerializeField] private ClickItem _clickItem;

    public void Click()
    {
        _clickItem.OnClick();
    }
}
