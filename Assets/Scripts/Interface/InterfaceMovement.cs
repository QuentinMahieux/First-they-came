using UnityEngine;
using UnityEngine.EventSystems;


public class InterfaceMovement : MonoBehaviour, IDragHandler
{
    public Canvas canvas;
    
    private RectTransform rectTransform;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        transform.SetAsLastSibling();
    }
    
}
