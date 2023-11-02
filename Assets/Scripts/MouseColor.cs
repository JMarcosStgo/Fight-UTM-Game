using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text textMeshPro;
    public Color hoverColor;
    private Color originalColor;

    void Start()
    {
        originalColor = textMeshPro.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMeshPro.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMeshPro.color = originalColor;
    }
}
