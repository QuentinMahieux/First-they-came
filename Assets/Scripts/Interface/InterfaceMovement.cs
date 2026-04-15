using UnityEngine;
using UnityEngine.EventSystems;


public class InterfaceMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas canvas;
    public OpenFolder folderParent;
    
    [Header("Game Settings")]
    public bool isOpenDefault =  false;
    private bool isOnDrag = false;
    
    private RectTransform rectTransform;
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (!isOpenDefault) folderParent.ClickFolder();
        isOnDrag = false;
        
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        isOnDrag = true;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        transform.SetAsLastSibling();
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        isOnDrag = false;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1) &&  isOnDrag)
        {
            folderParent.ClickFolder();
        }
    }
    
}
