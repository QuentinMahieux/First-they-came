using UnityEngine;

public class SpawnDrive : MonoBehaviour
{
    public Transform[] roadTransformStarts;
    
    [SerializeField] private float timeToSpawn;

    void Start()
    {
        timeToSpawn = 0;
    }
    void Update()
    {
        if (!GameManager.instance.isScanning)
        {
            timeToSpawn += Time.deltaTime;

            if (timeToSpawn >= GameManager.instance.dayDatas[GameManager.instance.actualDay].intervaToSpawn)
            {
                AddDriver();
            }
        }
    }

    void AddDriver()
    {
        //Spawn sur une route aléatoire
        Transform randomRoad = roadTransformStarts[Random.Range(0, roadTransformStarts.Length)];
        
        
        int actualDay = GameManager.instance.actualDay;
        int numberDriveSpawn = GameManager.instance.numberDriveSpawn;
        
        
        timeToSpawn = 0;
        GameObject drivePrefab = Instantiate(GameManager.instance.dayDatas[actualDay].driverDatas[numberDriveSpawn].carPrefab, randomRoad.position, Quaternion.identity);
        Drive actualDrive = drivePrefab.GetComponent<Drive>();
        actualDrive.InstanceDriver(GameManager.instance.dayDatas[actualDay].driverDatas[numberDriveSpawn]);
        
        GameManager.instance.numberDriveSpawn++;
        
    }
}
