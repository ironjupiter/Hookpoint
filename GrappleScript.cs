using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hook_pf;
    bool fired = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v2 = new Vector2(Input.mousePosition.x - Screen.width/2 , 
            Input.mousePosition.y - Screen.height / 2);
        Debug.Log(v2);

        if (Input.GetAxis("Fire1") != 0 && !fired)
        {
            fired = true;
            GameObject hook = Instantiate(hook_pf);
            hook.transform.position = this.transform.position;
            hook.GetComponent<HookScript>().player = this.gameObject;
            float force_multiplier = 1000;
            hook.GetComponent<Rigidbody2D>().AddForce(v2.normalized * force_multiplier);
        }
        else if (Input.GetAxis("Fire1") == 0)
        {
            fired = false;
        }
    }
}
