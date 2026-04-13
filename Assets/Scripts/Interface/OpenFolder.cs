using UnityEngine;

public class OpenFolder : MonoBehaviour
{
    public InterfaceMovement interfaceToOpen;
    public bool isOpen;

    public void ClickFolder()
    {
        OpenInterface(!isOpen);
    }
    
    private void OpenInterface(bool isOpening)
    {
        isOpen = isOpening;
        interfaceToOpen.transform.position = transform.position;
        interfaceToOpen.gameObject.SetActive(isOpen);
        interfaceToOpen.transform.SetAsLastSibling();
    }
}
