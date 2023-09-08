using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    public GameObject player;
    private float timer = 3;
    private float time;
    private float dmg = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            return;
        }

        if (collision.tag == "Attachable") {
            collision.GetComponent<SpringJoint2D>().enabled = true;
            collision.GetComponent<SpringJoint2D>().enableCollision = true;
            collision.GetComponent<SpringJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            collision.GetComponent<SpringJoint2D>().autoConfigureDistance = false;
            collision.GetComponent<SpringJoint2D>().distance = 0;
            collision.GetComponent<HealthSystem>().changeHealth(-dmg);
            Object.Destroy(this.gameObject);
            return;
        }

        if (collision.tag == "Unattachable") 
        {
            Object.Destroy(this.gameObject);
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
        if (Input.GetAxis("Fire2") != 0) {
            Object.Destroy(this.gameObject);
        }
    
        if (this.GetComponent<SpringJoint2D>().enabled == true)
        {
            this.GetComponent<SpringJoint2D>().autoConfigureDistance = false;
            this.GetComponent<SpringJoint2D>().distance = 0;
            return;
        }

        time += Time.deltaTime;
        if (time > timer) {
            Object.Destroy(this.gameObject);
        }
    }

    public void changeTimer(float alpha)
    {
        timer = alpha;
    }
    
    public void changeHookDMG(float alpha)
    {
        dmg = alpha;
    }
}
