using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammingBehavior : MonoBehaviour
{
    public bool can_be_rammed = false;
    public bool can_ram_player = false;
    public bool can_ram_unattached = false;
    public bool can_ram_attached = false;
    
    
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
        if (this.can_be_rammed == false)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player") == true && 
            (this.gameObject.CompareTag("Unattachable") || this.gameObject.GetComponent<SpringJoint2D>().enabled == false))
        {
            Debug.Log(this.gameObject.tag + " : no bounce");
            return;
        }

        if (this.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<RammingBehavior>().can_ram_player)
        {
            this.GetComponent<HealthSystem>().changeHealth(-collision.gameObject.GetComponent<RammingBehavior>().ramming_dmg);
            //this.GetComponent<ForcedPush>().pushObj(collision.transform.GetComponent<ForcedPush>().force, collision.gameObject);
        } 
        else if(this.gameObject.CompareTag("Unattachable") && collision.gameObject.GetComponent<RammingBehavior>().can_ram_unattached)
        {
            this.GetComponent<HealthSystem>().changeHealth(-collision.gameObject.GetComponent<RammingBehavior>().ramming_dmg);
            this.GetComponent<ForcedPush>().pushObj(collision.transform.GetComponent<ForcedPush>().force, collision.gameObject);
        } 
        else if (this.gameObject.CompareTag("Attachable") && collision.gameObject.GetComponent<RammingBehavior>().can_ram_attached)
        {
            this.GetComponent<HealthSystem>().changeHealth(-collision.gameObject.GetComponent<RammingBehavior>().ramming_dmg);
            this.GetComponent<ForcedPush>().pushObj(collision.transform.GetComponent<ForcedPush>().force, collision.gameObject);
        }
    }

    public void changeRammingDMG(float delta)
    {
        ramming_dmg += delta;
    }
}
