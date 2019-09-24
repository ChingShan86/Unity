using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformManager : MonoBehaviour
{
    public Text score;
    public Transform player;
    public Transform deadZone;
    public List<Transform> lands;
    public float landGap = 7;

    public readonly int MIN_LANDS = 3;
    public readonly int MAX_LANDS = 10;

    public readonly float iniLandPosX = 0;
    public readonly float iniLandPosY = 0;

    public static int layer = 1;

    void Start()
    {
        lands = new List<Transform>();
        for (int i = 1; i <= MAX_LANDS; i++)
        {
            SpawnLand();
        }
    }

    void Update()
    {
        ControlSpawnLand();
        CountLayer();
    }


    // 控制地板數量 不要太多也不要太少
    void ControlSpawnLand()
    {
        if (LandNumsAbovePlayer() < MIN_LANDS)
        {
            SpawnLand();
            if (lands.Count > MAX_LANDS)
            {
                DestroyLand();
            }
        }

    }

    int LandNumsAbovePlayer()
    {
        int landNumsAbovePlayer = 0;
        foreach (Transform land in lands)
        {
            if (land.transform.position.y > player.transform.position.y)
            {
                landNumsAbovePlayer++;
            }
        }
        return landNumsAbovePlayer;
    }

    // 生成一個地板
    void SpawnLand()
    {
        GameObject newLand = Instantiate(Resources.Load<GameObject>("Land"));
        newLand.transform.position = new Vector3(NewLandPosX(), NewLandPosY(), 0);
        lands.Add(newLand.transform);
    }

    void DestroyLand()
    {
        UpdateDeadZonePosY(lands[3].position.y + landGap/2);
        Destroy(lands[0].gameObject);
        lands.RemoveAt(0);
    }

    void UpdateDeadZonePosY(float newPosY)
    {
        deadZone.position = new Vector3(deadZone.position.x,newPosY,0);
    }

    // 決定地板的x值和y值
    float NewLandPosX()
    {
        if (lands.Count == 0)
        {
            return iniLandPosX;
        }
        return Random.Range(-7, 7);
    }
    float NewLandPosY()
    {
        if (lands.Count == 0)
        {
            return iniLandPosY;
        }
        return lands[lands.Count-1].transform.position.y + landGap;
    }


    ///計算層數
    void CountLayer()
    {
        layer = Mathf.CeilToInt(player.transform.position.y / landGap);
        score.text = layer.ToString();
    }

}
