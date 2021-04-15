using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class over_panel : MonoBehaviour {

    public Text scoretext;
    public Button restart;
    public Button back;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        restart = transform.Find("restart").GetComponent<Button>(); //按钮赋值
        restart.onClick.AddListener(RestartButtonEvent); //委托 绑定事件
        back = transform.Find("back").GetComponent<Button>(); //按钮赋值
        back.onClick.AddListener(BackButtonEvent); //委托 绑定事件
        
        
	}
	
	// Update is called once per frame
	void Update () {

        scoretext.text =Running_Panel.score.ToString();
	}
    public void RestartButtonEvent()
    {
        Audio_control.sound.playbutton();
        //清除运行场景中的敌机和子弹
        Destroy(GameObject.FindGameObjectsWithTag("bullet1"));
        Destroy(GameObject.FindGameObjectsWithTag("enemy1"));
        Destroy(GameObject.FindGameObjectsWithTag("enemy2"));
        Destroy(GameObject.FindGameObjectsWithTag("enemy3"));
        Destroy(GameObject.FindGameObjectsWithTag("Daoju"));
        //重置分数和生命值
        Running_Panel.hp = 100;
        Running_Panel.score = 0;
        //恢复 生成敌机
        GameObject.Find("Main Camera").GetComponent<game_controller>().Create();
        //生成自己的飞机
        Instantiate(Resources.Load("player"),new Vector2(0,-3),Quaternion.identity);
        //隐藏 over_panel界面
        gameObject.SetActive(false);

    }
    //删除一组物体方法 系统是删除一个物体
    private void Destroy(GameObject[] Objects)
    {
        for(int i=0;i<Objects.Length;i++)
        {
            Destroy(Objects[i]);
        }
    }


    //返回主菜单
     void BackButtonEvent()
    {
        Audio_control.sound.playbutton();
        //隐藏运行界面  parent相当于transform类型 因此可以用Find（）
        transform.parent.Find("running_panel").gameObject.SetActive(false);
        //显示开始界面
        transform.parent.Find("start_panel").gameObject.SetActive(true);
        //隐藏结束界面
        gameObject.SetActive(false);
    }
        
}
