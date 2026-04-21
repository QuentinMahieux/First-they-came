using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PermisInformation : MonoBehaviour
{
    public static PermisInformation instance;

    public TMP_Text name;
    public TMP_Text firstname;
    public TMP_Text age;
    public TMP_Text nationality;

    public Image permisType;
    public Image valididy;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeInformation(DriverData driverData)
    {
        name.text = driverData.familyName;
        firstname.text = driverData.firstName;
        age.text = driverData.age.ToString();
        nationality.text = driverData.nationality.ToString();

        if (driverData.licenceType == LicenceType.Apprentie)
        {
            permisType.color = Color.softYellow;
        }
        else if ( driverData.licenceType == LicenceType.Normal)
        {
            permisType.color = Color.white;
        }
        else
        {
            permisType.color = Color.lightCoral;
        }

        valididy.gameObject.SetActive(driverData.validity);
        
    }
    
}
