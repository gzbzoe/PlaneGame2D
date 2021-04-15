using UnityEngine;
using System.Collections;

public class bullet_moves : MonoBehaviour {

    Rigidbody2D rig;
    public float force = 500f;
    // Use this for initialization
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();//获取刚体
        rig.AddForce(Vector3.up * force);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
