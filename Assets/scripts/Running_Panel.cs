using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Running_Panel : MonoBehaviour {
    public Sprite paused;//zanting图片
    public Sprite start; //恢复图片
    public Text hpText;  //生命值文本框
    public Text scoreText;  //分数文本框
    public static int hp=100; //玩家生命值
    public static int score=0;
    // Use this for initialization
    //判断场景是否运行
    bool IsRunning=true;
    
    /*void Awake()   //程序最先执行的方法 且执行一次
    {
        Time.timeScale = 1;
    }*/
    void Start () {

        gameObject.SetActive(false);
       // hpText = GameObject.Find("Canvas/running_panel/HP").GetComponent<Text>();
        hpText=transform.Find("HP").GetComponent<Text>();
        hpText.text = "生命值:" + hp.ToString();
        //scoreText = GameObject.Find("Canvas/running_panel/Score").GetComponent<Text>();
        scoreText = transform.Find("Score").GetComponent<Text>();
        scoreText.text = "分数：" + score.ToString();

    }
	
	// Update is called once per frame
	void Update () {

        hpText.text = "生命值:" + hp;
        scoreText.text = "分数:" + score;
    }
    public void PauseButtonEvent()   //开始
    {
        //Time.timeScale = 0;  游戏静止
        //开始游戏
        //开始按钮隐藏 停止按钮显示

        //一个物体隐藏
        Audio_control.sound.playbutton();
        if (IsRunning)
        {
            IsRunning = false;
            Time.timeScale = 0;
            //GameObject.Find("Canvas/running_panel/pause").GetComponent<Button>();
            transform.Find("pause").GetComponent<Image>().sprite = start;
            /*GameObject.Find("Audio").GetComponent<AudioSource>().Stop();*/
        }
        else
        {
            IsRunning = true;
            Time.timeScale = 1;
            transform.Find("pause").GetComponent<Image>().sprite = paused;
            /*GameObject.Find("Audio").GetComponent<AudioSource>().Play();*/
        }
     
                                                          //一个物体显示
       

    }
}
