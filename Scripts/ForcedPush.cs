using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedPush : MonoBehaviour
{
    // Start is called before the first frame update
    public float force = 0;
    public bool canBePushed = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pushObj(float force, GameObject go)
    {
        if (canBePushed == false)
        {
            return;
        }

        Vector2 v2 = -go.gameObject.transform.position + this.gameObject.transform.position;
        this.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(force*v2.normalized*go.GetComponent<Rigidbody2D>().mass, go.gameObject.transform.position);
    }
}
