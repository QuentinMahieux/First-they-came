using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    public static RuleManager instance;
    
    public List<ProhibitionData> prohibitionDatas;
    public List<RuleChekUp> ruleChekUps;
    
    void Start()
    {
        ResetRule();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChekRule();
        }
    }

    public void AddRule(ProhibitionData prohibitionData)
    {
        prohibitionDatas.Add(prohibitionData);
    }

    void ResetRule()
    {
        ruleChekUps = new List<RuleChekUp>();
        foreach (ProhibitionData prohibitionData in prohibitionDatas)
        {
            ruleChekUps.Add(new RuleChekUp());
            ruleChekUps[^1].prohibitionData =  prohibitionData;
        }
    }

    void ChekRule()
    {
        foreach (RuleChekUp ruleChekUp in ruleChekUps)
        {
            if (ruleChekUp.prohibitionData is ProhibitionNumberData prohibitionNumberData)
            {
                ruleChekUp.isValid = CheckNumberRule(prohibitionNumberData);
            }
        }
    }

    bool CheckNumberRule(ProhibitionNumberData data)
    {
        switch (data.numberType)
        {
            case NumberType.age:
                return CheckSpecificNumberRule(GameManager.instance.actualDriver.age, data);
                break;
            case NumberType.speedLimit:
                return CheckSpecificNumberRule(GameManager.instance.actualDriver.speed, data);
                break;
        }
        return false;
    }

    bool CheckSpecificNumberRule(float value, ProhibitionNumberData data)
    {
        switch (data.symbolType)
        {
            case symbolType.superieur:
                if(value > data.number) return true;
                break;
            case symbolType.inferieur:
                if(value < data.number) return true;
                break;
            case symbolType.egal:
                if(value == data.number) return true;
                break;
        }
        return false;
    }
    
    
}
[System.Serializable]
public class RuleChekUp
{
    public bool isCheked;
    public bool isValid;
    public ProhibitionData prohibitionData;
}