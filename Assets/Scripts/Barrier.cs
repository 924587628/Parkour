using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {

    public Transform[] barrierPoints;
    public GameObject[] barrierPrefabs;


    /// <summary>
    /// 创建障碍物
    /// </summary>
    public void CreateBarriers()
    {
        //随机获取障碍物生成的位置
        int point = Random.Range(0, barrierPoints.Length);
        for (int i = 0; i <= point; i++)
        {
        Transform bp = barrierPoints[i];
        //随机获取障碍物的预制体
        int barrier = Random.Range(1, barrierPrefabs.Length);
        Transform bpt = barrierPrefabs[barrier].transform;
        //随机生成障碍物的个数
        int barrierCount = Random.Range(1, 3);
        for (int j = 0; j <= barrierCount; j++)
        {

            GameObject b = GameObject.Instantiate(barrierPrefabs[barrier],
                Vector3.zero, Quaternion.identity) as GameObject;
            b.transform.parent = bp;
            b.transform.localPosition = new Vector3(0 + j * 0.42f, bpt.position.y, bp.position.z);
        }
        }
    }

    public void DestroyBarriers()
    {
        for (int i = 0; i < barrierPoints.Length; i++)
        {
            for (int j = 0; j < barrierPoints[i].childCount; j++)
            {
                Destroy(barrierPoints[i].GetChild(j).gameObject);
            }
        }
    }
}
