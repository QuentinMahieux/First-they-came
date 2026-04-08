using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance;

    [Header("Day")]
    [SerializeField] private DayData[] dayDatas;
    [SerializeField] private int actualDay;
    
    [Header("Driver")]
    public DriverData actualDriver;
    [SerializeField] private Transform roadTransform;
    private GameObject roadPrefab;
    
    [Header("Camera")]
    public CameraCapture[] camerasCaptures = new CameraCapture[2];
    
    [Header("Game Stat")]
    [Tooltip("Phase de jeu dans laquel on veritie les informations de la voiture")]
    public bool isScanning;
    
    
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
        NewDay();
    }

    void NewDay()
    {
        
        //Met a jour la route
        if (roadPrefab) Destroy(roadPrefab);
        roadPrefab = Instantiate(dayDatas[actualDay].roadPrefab, roadTransform.position, roadTransform.rotation);

        int index = 0;
        foreach (Transform drive in roadPrefab.GetComponentsInChildren<Transform>())
        {
            if(drive.gameObject.CompareTag("DriveEmplacement") && index <= dayDatas[actualDay].driverDatas.Length)
            {
                roadPrefab = Instantiate(dayDatas[actualDay].driverDatas[index].carPrefab, drive.position, Quaternion.identity);
                Drive actualDrive = roadPrefab.GetComponent<Drive>();
                actualDrive.InstanceDriver(dayDatas[actualDay].driverDatas[index]);
                index++;
            }
        }
        actualDay++;
    }

    void EndDay()
    {
        
    }

    public void ScanDrive(DriverData driverData)
    {
        isScanning = true;
        actualDriver = driverData;

        foreach (CameraCapture cam in camerasCaptures)
        {
            cam.TakePhoto();
        }
        
        //ChangeInterface
        DriveInformation.instance.ChangeText(actualDriver);
    }
    
    
    
}
