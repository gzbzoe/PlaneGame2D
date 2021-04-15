using UnityEngine;
using System.Collections;

public class DaoJu_move : MonoBehaviour {

    public float speed = 4;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            Audio_control.sound.playget_bomb();
            player_move.IsRed = true;
            Destroy(gameObject);

        }
        if (col.gameObject.name == "bullet1(Clone)")
        {
            
            Destroy(col.gameObject);

        }

    }
}
