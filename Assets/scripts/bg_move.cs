 using UnityEngine;
using System.Collections;

public class bg_move : MonoBehaviour {

    public float speed = 5f;
    Vector3 startpos;//开始位置
	// Use this for initialization
	void Start () {

        startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y<-9)
        {
            transform.position = startpos;
        }
        
    }
}
