using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance;

    [Header("Day")]
    [SerializeField] public DayData[] dayDatas;
    [SerializeField] public int actualDay;
    
    [Header("Driver")]
    public DriverData actualDriver;

    [HideInInspector] public int numberDriveSpawn;
    [SerializeField] private Transform roadTransform;
    
    [Header("Camera")]
    public Camera verificationCamera;
    public Camera radarCamera;
    
    
    [Header("Game Stat")]
    [Tooltip("Phase de jeu dans laquel on veritie les informations de la voiture")]
    public bool isScanning;
    
    [Header("Settings")]
    public SceneSettingData settings;
    
    
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
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        numberDriveSpawn = 0;
        VerificationToRadar();
    }

    public void RadarToVerication(DriverData driverData)
    {
        verificationCamera.gameObject.SetActive(true);
        radarCamera.gameObject.SetActive(false);
        
        isScanning = true;
        actualDriver = driverData;
        
        RuleManager.instance.ResetRule();
        
        //ChangeInterface
        DriveInformation.instance.ChangeText(actualDriver);
        PermisInformation.instance.ChangeInformation(actualDriver);
    }
    
    public void VerificationToRadar()
    {
        verificationCamera.gameObject.SetActive(false);
        radarCamera.gameObject.SetActive(true);
        
        isScanning = false;
        actualDriver = null;
    }
    
    
    
}
