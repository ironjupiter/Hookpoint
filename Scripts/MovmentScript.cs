using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentScript : MonoBehaviour
{
    Rigidbody2D rb;
    float walk_speed = 5f;
    float run_speed = 10f;
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

        if (rb.velocity.magnitude > walk_speed && Input.GetAxis("Run") == 0)
        {
            return;
        }
        else if (rb.velocity.magnitude > run_speed) 
        {
            return;
        }
        rb.AddRelativeForce(v2 * 15);
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
}
