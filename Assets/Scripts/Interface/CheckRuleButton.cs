using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckRuleButton : MonoBehaviour
{
    public int id;
    public Image checkImage;
    public TMP_Text ruleDescription;
    
    
    [SerializeField] private bool ischecked;

    void Start()
    {
        ischecked = false;
        checkImage.enabled = ischecked;
    }

    public void Reset(int newId, string newDescription)
    {
        this.id = newId;
        ischecked = false;
        checkImage.enabled = ischecked;
        
        ruleDescription.text = newDescription;
    }

    public void CheckCase()
    {
        ischecked = !ischecked;
        checkImage.enabled = ischecked;
        RuleManager.instance.ChangeCheckRule(id, ischecked);
    }
}
