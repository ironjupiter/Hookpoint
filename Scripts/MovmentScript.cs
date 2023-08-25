using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentScript : MonoBehaviour
{
    Rigidbody2D rb;
    float walk_speed = 15f;
    float dash_force = 1000f;

    private float dash_timer = 1f;
    private float current_time = 0;
    private bool has_dashed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementBasic();
    }

    public void MovementBasic() {
        Vector2 v2 = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        Xmovement(x);
        Ymovement(y);
        
        dash(x, y);
    }

    private void dash(float x, float y)
    {
        if (Input.GetAxis("Run") != 0 && !has_dashed)
        {
            rb.AddForce(new Vector2(x,y) * dash_force);
            has_dashed = true;
        }

        if (has_dashed)
        {
            current_time += Time.deltaTime;
        }

        if (current_time > dash_timer && Input.GetAxis("Run") == 0)
        {
            current_time = 0;
            has_dashed = false;
        }
    }

    private void Xmovement(float x)
    {
        if ((walk_speed < this.GetComponent<Rigidbody2D>().velocity.x && this.GetComponent<Rigidbody2D>().velocity.x/x < 0) || (walk_speed > this.GetComponent<Rigidbody2D>().velocity.x))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(x*walk_speed, 0));
        }
    }

    private void Ymovement(float y)
    {
        if ((walk_speed < this.GetComponent<Rigidbody2D>().velocity.y && this.GetComponent<Rigidbody2D>().velocity.y/y < 0) || (walk_speed > this.GetComponent<Rigidbody2D>().velocity.y))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0*walk_speed, y*walk_speed));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attachable") {
            collision.gameObject.GetComponent<SpringJoint2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hook" && collision.gameObject.GetComponent<SpringJoint2D>().enabled == true)
        {
            Object.Destroy(collision.gameObject);
        }
    }
    
    //public void change
}
