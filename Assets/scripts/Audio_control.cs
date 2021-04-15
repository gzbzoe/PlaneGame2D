using UnityEngine;
using System.Collections;

public class Audio_control : MonoBehaviour {
    public static Audio_control sound;
    public AudioSource bgmusic;
    public AudioClip enemy1_die;
    public AudioClip enemy2_die;
    public AudioClip enemy3_die;
    public AudioClip get_bomb;
    public AudioClip bullet;
    public AudioClip gameover;
    public AudioClip clickbutton;
    // Use this for initialization
    void Start () {

        sound = this;
        bgmusic = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void playenem1_die()
    {
        bgmusic.PlayOneShot(enemy1_die);
    }
    public void playenem2_die()
    {
        bgmusic.PlayOneShot(enemy2_die);
    }
    public void playenem3_die()
    {
        bgmusic.PlayOneShot(enemy3_die);
    }
    public void playget_bomb()
    {
        bgmusic.PlayOneShot(get_bomb);
    }
    public void playbullet()
    {
        bgmusic.PlayOneShot(bullet);
    }
    public void playgame_over()
    {
        bgmusic.PlayOneShot(gameover);
    }
    public void playbutton()
    {
        bgmusic.PlayOneShot(clickbutton);
    }
}
