using System.Collections.Generic;
using UnityEngine;

public class CasierJudicierManager : MonoBehaviour
{
    public static CasierJudicierManager instance;

    public List<CasierJudicier> CasierJudiciers;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one CasierJudicierManager in the scene");
            Destroy(gameObject);
        }
    }

    public void RemovePoint(DriverData driverData, ProhibitionData prohibitionData)
    {
        bool isFind = false;
        foreach (CasierJudicier casierJudicier in CasierJudiciers)
        {
            if (casierJudicier.driverData.id == driverData.id)
            {
                casierJudicier.prohibitionDatas.Add(prohibitionData);
                casierJudicier.permisPoint -= prohibitionData.pointRemoved;
                isFind = true;
            }
        }

        if (!isFind)
        {
            CasierJudicier newCasierJudiciers = new CasierJudicier();
            newCasierJudiciers.prohibitionDatas = new List<ProhibitionData>();

            newCasierJudiciers.driverData = driverData;
            newCasierJudiciers.permisPoint = driverData.defaultPermisPoint;
            newCasierJudiciers.permisPoint -= prohibitionData.pointRemoved;

            newCasierJudiciers.prohibitionDatas.Add(prohibitionData);
            
            
            CasierJudiciers.Add(newCasierJudiciers);
        }
    }
}


[System.Serializable]
public class CasierJudicier
{
    public DriverData driverData;
    public int permisPoint;
    public List<ProhibitionData> prohibitionDatas  = new List<ProhibitionData>();
}