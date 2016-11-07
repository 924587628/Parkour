using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    public static GameManager Instance
    {
        get{return _instance;}
    }

    private float f_dis = 0;
    private int dis = 0;
    private int bonus = 0;

    private Text goldText;
    private Text distanceText;
    private GameObject go;
    

    private BackgroundTranform bgT;

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
        goldText = GameObject.Find("GoldText").GetComponent<Text>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
        bgT = GameObject.Find("Background1").GetComponent<BackgroundTranform>();
        go = GameObject.Find("GameOver");

        go.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDistance();
	}

    private void UpdateDistance()
    {
        f_dis += bgT.moveSpeed * Time.deltaTime;
        dis = (int)f_dis;
        
        distanceText.text = dis.ToString();
    }

    public void GameOver()
    {
        GameObject[] bg = GameObject.FindGameObjectsWithTag("Background");
        foreach (GameObject i in bg)
        {
            i.GetComponent<BackgroundTranform>().enabled = false;
        }
        GameObject.Find("Player").GetComponent<Animator>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        this.enabled = false;
        go.SetActive(true);
    }

    public void UpdateBonus(int count)
    {
        bonus += count;
        goldText.text = bonus.ToString();

    }

    public void RestartClick()
    {
        Application.LoadLevel(1);
        go.SetActive(false);
    }

    public void ExitClick()
    {
        Application.LoadLevel(0);
    }
}
