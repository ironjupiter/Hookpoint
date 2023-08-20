using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammingBehavior : MonoBehaviour
{
    public bool can_be_rammed = false;
    public float ramming_dmg = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (can_be_rammed == true && collision.gameObject.tag == "Player") 
        {
            if (this.gameObject.tag == "Unattachable") 
            {
                return;
            }

            this.GetComponent<HealthSystem>().
                changeHealth(-collision.gameObject.GetComponent<RammingBehavior>().ramming_dmg);

            return;
        }


        if (can_be_rammed == true)
        {
            this.GetComponent<HealthSystem>().
                changeHealth(-collision.gameObject.GetComponent<RammingBehavior>().ramming_dmg);
        }
    }
}
