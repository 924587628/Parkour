using UnityEngine;
using System.Collections;

public class BackgroundTranform : MonoBehaviour {

    public float moveSpeed = 2f;

    //private Barrier barrier;
    public GameObject[] mapPrefabs;

	// Use this for initialization
	void Start () {
        //barrier = GetComponent<Barrier>();
	}
	
	// Update is called once per frame
	void Update () {
        //moveSpeed += Time.deltaTime;
        this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        Vector3 position = this.transform.position;
        if (position.x <= -20)
        {
            //barrier.DestroyBarriers();
            CreateBackground();
            Destroy(this.gameObject);
        }
	}

    private void CreateBackground()
    {
        int i = Random.Range(0, mapPrefabs.Length);
        GameObject.Instantiate(mapPrefabs[i], new Vector3(20, 0, 0), Quaternion.identity);
    }
}
