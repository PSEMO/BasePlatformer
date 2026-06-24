using UnityEngine;

public class Panel : MonoBehaviour
{
    public MenuType Type;

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
