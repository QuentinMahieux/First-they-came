using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    public static RuleManager instance;
    
    public List<ProhibitionData> prohibitionDatas;
    public List<RuleChekUp> ruleChekUps;

    [Tooltip("Gameobject cotnenant l'essemble des ChekRuleButton")]
    public GameObject ruleChekerElement;

    [Header("Drive Valide")]
    public List<DrivePunish> drivePunishs;

    void Awake()
    {
        if (!instance) instance = this;
        else
        {
            Debug.LogError("💥 More than one instance of RuleManager");
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        ResetRule();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChekRule(GameManager.instance.actualDriver);
        }
    }

    //Ajoute 
    public void AddRule(ProhibitionData prohibitionData)
    {
        prohibitionDatas.Add(prohibitionData);
    }

    //Resert les regle
    void ResetRule()
    {
        ruleChekUps = new List<RuleChekUp>();
        foreach (ProhibitionData prohibitionData in prohibitionDatas)
        {
            ruleChekUps.Add(new RuleChekUp());
            ruleChekUps[^1].prohibitionData =  prohibitionData;
        }

        int index = 0;
        foreach (CheckRuleButton ruleChekUp in ruleChekerElement.GetComponentsInChildren<CheckRuleButton>())
        {
            if (ruleChekUps.Count > index)
            {
                ruleChekUp.gameObject.SetActive(true);
                ruleChekUp.Reset(index, ruleChekUps[index].prohibitionData.descrition);
            }
            else
            {
                ruleChekUp.gameObject.SetActive(false);
            }
            index++;
        }
    }

    //Regarde si un passager et en règle
    void ChekRule(DriverData driverData)
    {
        foreach (RuleChekUp ruleChekUp in ruleChekUps)
        {
            if (ruleChekUp.prohibitionData is ProhibitionNumberData prohibitionNumberData)
            {
                ruleChekUp.isValid = CheckNumberRule(prohibitionNumberData, driverData);
            }
        }
    }

    //Coche ou decoche une suspition de règle enfrint
    public void ChangeCheckRule(int id, bool newIsChecked)
    {
        ruleChekUps[id].isCheked = newIsChecked;
    }
    
    //Regarde si une regle d'entier, contient l'age ou la limite
    bool CheckNumberRule(ProhibitionNumberData prohibitionNumberData, DriverData driverData)
    {
        switch (prohibitionNumberData.numberType)
        {
            case NumberType.age:
                return CheckSpecificNumberRule(driverData.age, prohibitionNumberData);
                break;
            case NumberType.speedLimit:
                return CheckSpecificNumberRule(driverData.speed, prohibitionNumberData);
                break;
        }
        return false;
    }

    //Regarde si un nombre est >,<,= à la règle
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

    public void VerifyRule()
    {
        DrivePunish newDrivePunish = new DrivePunish();
        newDrivePunish.driverData = GameManager.instance.actualDriver;
        foreach (RuleChekUp rule in ruleChekUps)
        {
            if (rule.isValid == rule.isCheked &&  rule.isValid)
            {
                newDrivePunish.valideProhibitionDatas.Add(rule.prohibitionData);
            }
            else if (!rule.isCheked && rule.isValid)
            {
                newDrivePunish.forgetProhibitionDatas.Add(rule.prohibitionData);
            }
            else if (rule.isCheked && !rule.isValid)
            {
                newDrivePunish.burrProhibitionDatas.Add(rule.prohibitionData);
            }
        }
        
        drivePunishs.Add(newDrivePunish);
    }
    
}
[System.Serializable]
public class RuleChekUp
{
    public bool isCheked;
    public bool isValid;
    public ProhibitionData prohibitionData;
}

[System.Serializable]
public class DrivePunish
{
    public DriverData driverData;
    
    public List<ProhibitionData> valideProhibitionDatas;
    public List<ProhibitionData> forgetProhibitionDatas;
    public List<ProhibitionData> burrProhibitionDatas;
}