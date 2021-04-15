using UnityEngine;
using System.Collections;

public class game_controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
      
    }
    //生成敌机
    public void Create()
    {
        InvokeRepeating("ProduceMaxFly", 4, 8);
        InvokeRepeating("ProduceEnemy1", 2, 5);
        InvokeRepeating("ProduceEnemy2", 1, 3);
        InvokeRepeating("ProduceDaoJu1", 1, 10);
    }
    //停止生成敌机
    public void Stop()
    {
        //停止InvokeRepeating方法 
        CancelInvoke("ProduceMaxFly");
        CancelInvoke("ProduceEnemy1");
        CancelInvoke("ProduceEnemy2");
        CancelInvoke("ProduceDaoJu1");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ProduceMaxFly()
    {
        GameObject go = Instantiate(Resources.Load("enemy3")) as GameObject;
        //transform.GetChild(1) 获取孩子
        go.transform.position = new Vector3(Random.Range(-1.96f,1.91f),3.49f,0);
        
    }
    public void ProduceEnemy1()
    {
        GameObject go = Instantiate(Resources.Load("enemy1")) as GameObject;
        //transform.GetChild(1) 获取孩子
        go.transform.position = new Vector3(Random.Range(-1.96f, 1.91f), 3.49f, 0);

    }
    public void ProduceEnemy2()
    {
        GameObject go = Instantiate(Resources.Load("enemy2")) as GameObject;
        //transform.GetChild(1) 获取孩子
        go.transform.position = new Vector3(Random.Range(-1.96f, 1.91f), 3.49f, 0);

    }
    public void ProduceDaoJu1()
    {
        GameObject go = Instantiate(Resources.Load("daoju2")) as GameObject;
        //transform.GetChild(1) 获取孩子
        go.transform.position = new Vector3(Random.Range(-1.96f, 1.91f), 3.49f, 0);

    }
}
