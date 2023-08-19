using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    public GameObject player;
    private float timer = 3;
    private float time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
            collision.GetComponent<SpringJoint2D>().enabled = true;
            collision.GetComponent<SpringJoint2D>().enableCollision = true;
            collision.GetComponent<SpringJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            collision.GetComponent<SpringJoint2D>().distance = 0;
            Object.Destroy(this.gameObject);
            return;
        }

        if (collision.tag != "Player")
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            this.GetComponent<SpringJoint2D>().enabled = true;
            this.GetComponent<SpringJoint2D>().enableCollision = true;
            this.GetComponent<SpringJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            this.GetComponent<SpringJoint2D>().distance = 0;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timer || Input.GetAxis("Fire2") != 0) {
            Object.Destroy(this.gameObject);
        }
    }
}
