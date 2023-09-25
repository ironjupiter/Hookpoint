using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private RammingBehavior rb;

    public float Timer = 5f;
    private float time_unconsious = 0f;
    private bool knocked_out = false;
    
    
    
    private void Start()
    {
        rb = this.gameObject.GetComponent<RammingBehavior>();
        rb.can_ram_attached = false;
        rb.can_ram_unattached = false;
    }

    public void Update()
    {
        if (Timer < time_unconsious && knocked_out == true)
        {
            knocked_out = false;
            time_unconsious = 0;
            Debug.Log("awake again");
            rb.can_ram_attached = false;
            rb.can_ram_unattached = false;
        } 
        else if (knocked_out == true)
        {
            time_unconsious += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Hook"))
        {
            Debug.Log("sanity check");
            rb.can_ram_attached = true;
            rb.can_ram_unattached = true;
            knocked_out = true;
        }
    }
}
