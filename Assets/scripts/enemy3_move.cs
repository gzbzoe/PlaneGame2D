using UnityEngine;
using System.Collections;

public class enemy3_move : MonoBehaviour
{
    SpriteRenderer Encmy_sprit;  //定义一个组件
    Sprite sprit; //当前图片
    public Sprite hitsprit; //受伤图片
    public float speed = 4;
    public int hp = 40;
    // Use this for initialization
    void Start()
    {
        Encmy_sprit = GetComponent<SpriteRenderer>();  //获取组件
        sprit = Encmy_sprit.sprite;//赋值当前图片
        /*hitsprit = Resources.Load("sprite/enemy2_hit") as Sprite; */ //受伤图片
        print(hitsprit);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
       
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
       //打印碰撞物体名字
        if(col.gameObject.name== "bullet1(Clone)")
        {
            //协程 间隔一段时间
            StartCoroutine(Hitanimation()); //方法名不能终止
            hit(20);
            Destroy(col.gameObject);
            //检测敌机生命值
            if (hp <= 0)
            {
                //死亡
                //死亡前播放死亡动画 打开animator组件
                
                GetComponent<Animator>().enabled = true;
                Destroy(gameObject, 1f);
                Destroy(GetComponent<Collider2D>());
                if (gameObject.tag == "enemy1")
                {
                    Audio_control.sound.playenem1_die();
                    Running_Panel.score++;
                }
                if (gameObject.tag == "enemy2")
                {
                    Audio_control.sound.playenem2_die();
                    Running_Panel.score += 2;
                }
                if (gameObject.tag == "enemy3")
                {
                    Audio_control.sound.playenem3_die();
                    Running_Panel.score += 5;
                }

               
            }
        }
        if (col.gameObject.tag == "bomb")
        {
            //协程 间隔一段时间
            StartCoroutine(Hitanimation()); //方法名不能终止
            hit(40);
            Destroy(col.gameObject);
            //检测敌机生命值
            if (hp <= 0)
            {
                //死亡
                //死亡前播放死亡动画 打开animator组件
                GetComponent<Animator>().enabled = true;
                Destroy(gameObject, 1f);
                Destroy(GetComponent<Collider2D>());
                if (gameObject.tag == "enemy1")
                {
                    Audio_control.sound.playenem1_die();
                    Running_Panel.score++;
                }
                if (gameObject.tag == "enemy2")
                {
                    Audio_control.sound.playenem2_die();
                    Running_Panel.score += 2;
                }
                if (gameObject.tag == "enemy3")
                {
                    Audio_control.sound.playenem3_die();
                    Running_Panel.score += 5;
                }


            }
        }

    }
    
    public void hit(int atk)
    {
        /*if(gameObject.tag=="enemy3")
        {
            hp -= 20;
        }
        if (gameObject.tag == "enemy2")
        {
            hp -= 5;
        }
        if (gameObject.tag == "enemy1")
        {
            hp -= 10;
        }*/
        hp -= atk;
       
    }
    IEnumerator Hitanimation()
    {
        //打的图片
        Encmy_sprit.sprite = hitsprit;
        yield return new WaitForSeconds(0.2f);//程序等待n秒后从当前位置继续执行
        //恢复
        Encmy_sprit.sprite = sprit;
    }

}