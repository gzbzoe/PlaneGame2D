using UnityEngine;
using System.Collections;

public class player_move : MonoBehaviour {
    /*public int hp;*/
    float startTime=0; //开始时间
    float FireTime = 0.2f; //间隔时间
    Vector3 mousepos;
    public float speed = 3f;
    public static bool IsRed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Fire();
        //获取鼠标坐标  Input.mousePosition
        //鼠标坐标转换成世界坐标 Camera.main.ScreenToWorldPoint(Input.mousePosition)
        //让飞机移动到鼠标世界坐标上
        if (Input.GetMouseButton(0))
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousepos.x, mousepos.y, transform.position.z);
            if (transform.position.x < -2.29)
            {
                transform.position = new Vector3(-2.29f, mousepos.y, transform.position.z);
            }
            if (transform.position.x > 2.31)
            {
                transform.position = new Vector3(2.31f, mousepos.y, transform.position.z);
            }
            if (transform.position.y < -4.31)
            {
                transform.position = new Vector3(mousepos.x, -4.31f, transform.position.z);
            }
            if (transform.position.y > 4.28)
            {
                transform.position = new Vector3(mousepos.x, 4.28f, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {

            //飞机向左移动 -x
            //this.GetComponent<Transform>().position  访问组件
            /*transform.position+= new Vector3(-1, 0, 0)*Time.deltaTime*speed;
            transform.position += Vector3.left * Time.deltaTime * speed;  节省性能*/
            transform.Translate(Vector3.left * Time.deltaTime * speed); //平移方法 参数为方向
            if (transform.position.x < -2.29)
            {
                transform.position = new Vector3(-2.29f, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {

            //飞机向左移动 -x
            //this.GetComponent<Transform>().position  访问组件
            /*transform.position+= new Vector3(-1, 0, 0)*Time.deltaTime*speed;
            transform.position += Vector3.left * Time.deltaTime * speed;  节省性能*/
            transform.Translate(Vector3.right * Time.deltaTime * speed); //平移方法 参数为方向
            if (transform.position.x > 2.31)
            {
                transform.position = new Vector3(2.31f, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {

            //飞机向左移动 -x
            //this.GetComponent<Transform>().position  访问组件
            /*transform.position+= new Vector3(-1, 0, 0)*Time.deltaTime*speed;
            transform.position += Vector3.left * Time.deltaTime * speed;  节省性能*/
            transform.Translate(Vector3.up * Time.deltaTime * speed); //平移方法 参数为方向
            if (transform.position.y > 4.28)
            {
                transform.position = new Vector3(transform.position.x, 4.28f, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {

            //飞机向左移动 -x
            //this.GetComponent<Transform>().position  访问组件
            /*transform.position+= new Vector3(-1, 0, 0)*Time.deltaTime*speed;
            transform.position += Vector3.left * Time.deltaTime * speed;  节省性能*/
            transform.Translate(Vector3.down * Time.deltaTime * speed); //平移方法 参数为方向
            if (transform.position.y < -4.31)
            {
                transform.position = new Vector3(transform.position.x, -4.31f, transform.position.z);
            }
        }
        if(Running_Panel.hp <= 0)
        {
            Running_Panel.hp = 0;
            GetComponent<Animator>().SetBool("IsDead", true);
            Audio_control.sound.playgame_over();
            Destroy(gameObject,1f);
            //停止生产敌机
            GameObject.Find("Main Camera").GetComponent<game_controller>().Stop();
            
            /*GetComponent<AudioSource>().Play();
            GameObject.Find("Audio").GetComponent<AudioSource>().Stop();*/
            //显示over界面
            GameObject.Find("Canvas").transform.Find("over_panel").gameObject.SetActive(true);
            

            // Application.Quit(); //打包后有效果


        }


    }
  

    ///开火的方法
    public void Fire()
    {
        
        startTime += Time.deltaTime;
        if(startTime>=FireTime)
        {
            //开火
            //Rescource.Load(" ") 动态加载资源的方法
            //从工程面板resources文件夹中加载资源
            //必须有recources
            //("")参数必须写对，资源名字
            if(IsRed)
            {
                GameObject go = Instantiate(Resources.Load("bomb")) as GameObject;
                go.transform.position = transform.GetChild(0).transform.position;
                startTime = 0;
                Destroy(go, 2f);
                StartCoroutine(back());
            }
            else {
                Audio_control.sound.playbullet();
                GameObject go = Instantiate(Resources.Load("bullet1")) as GameObject;
            //transform.GetChild(1) 获取孩子
            go.transform.position = transform.GetChild(0).transform.position;
            startTime = 0;
            Destroy(go, 2f);
            }
            
        }
    }
    IEnumerator back()
    {
        yield return new WaitForSeconds(3f);
        IsRed = false;
    }
    //玩家碰到敌机
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="enemy3")
        {
            Running_Panel.hp -= 20;
            Running_Panel.score += 5;
        }
        
        if (col.gameObject.tag == "enemy1")
        {
            Running_Panel.hp -= 10;
            Running_Panel.score++;
        }   
        if (col.gameObject.tag == "enemy2")
        {
            Running_Panel.hp -= 5;
            Running_Panel.score += 2;
        }
        if (col.gameObject.tag == "bullet1")  //撞到子弹不执行
        {
            return;
        }
        if (col.gameObject.tag == "Daoju")
        {
            Running_Panel.hp += 10;
            return;
        }
        if (col.gameObject.tag == "bomb")  //撞到子弹不执行
        {
            return;
        }
        Destroy(col.gameObject.GetComponent<Collider2D>());
        Destroy(col.gameObject, 1f);
        col.gameObject.GetComponent<Animator>().enabled = true;
    }
}
