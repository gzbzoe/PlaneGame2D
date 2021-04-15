using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class start_panel : MonoBehaviour {

    public Button startbtn;
    public Button quitbtn;
	// Use this for initialization
	void Start () {
       
        startbtn = transform.Find("startbutton").GetComponent<Button>(); //按钮赋值
        startbtn.onClick.AddListener(StartButtonEvent); //委托 绑定事件
        quitbtn = transform.Find("quitbutton").GetComponent<Button>(); //按钮赋值
        quitbtn.onClick.AddListener(QuitButtonEvent); //委托 绑定事件
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void StartButtonEvent()
    {
        Audio_control.sound.playbutton();
        //开始生成敌机
        GameObject.Find("Main Camera").GetComponent<game_controller>().Create();
        //生成自己的飞机
        Instantiate(Resources.Load("player"), new Vector2(0, -3), Quaternion.identity);
        //重置分数和生命值
        Running_Panel.hp = 100;
        Running_Panel.score = 0;
        //显示运行界面
        transform.parent.Find("running_panel").gameObject.SetActive(true);
        //隐藏开始界面
        gameObject.SetActive(false);
    }
    void QuitButtonEvent()
    {
        Audio_control.sound.playbutton();
       
        Application.Quit();
    }
}
