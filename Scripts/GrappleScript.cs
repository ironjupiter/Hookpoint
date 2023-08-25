using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hook_pf;
    bool fired = false;

    float fire_rate = 2f;
    float fire_timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v2 = new Vector2(Input.mousePosition.x - Screen.width/2 , 
            Input.mousePosition.y - Screen.height / 2);
       
        if (Input.GetAxis("Fire1") != 0 && !fired)
        {
            fired = true;
            GameObject hook = Instantiate(hook_pf);
            hook.transform.position = this.transform.position;
            hook.GetComponent<HookScript>().player = this.gameObject;
            hook.GetComponent<HookScript>().changeTimer(fire_rate);
            float force_multiplier = 5000;
            hook.GetComponent<Rigidbody2D>().AddForce(v2.normalized * force_multiplier);
        }
        else if (Input.GetAxis("Fire1") == 0 && fire_timer > fire_rate)
        {
            fired = false;
            fire_timer = 0;
        }
        else if (fired == true)
        {
            fire_timer += Time.deltaTime;
        }
    }

    public void changeFireRate(float delta)
    {
        fire_rate += delta;
        if (fire_rate < .01f)
        {
            fire_rate = .01f;
        }
    }
}
