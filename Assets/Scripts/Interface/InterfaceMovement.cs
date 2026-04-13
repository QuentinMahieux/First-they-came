using UnityEngine;
using UnityEngine.EventSystems;


public class InterfaceMovement : MonoBehaviour, IDragHandler
{
    public Canvas canvas;
    public OpenFolder folderParent;
    
    [Header("Game Settings")]
    public bool isOpenDefault =  false;
    
    private RectTransform rectTransform;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (!isOpenDefault) folderParent.ClickFolder();
        
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        transform.SetAsLastSibling();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            folderParent.ClickFolder();
        }
    }
    
}
