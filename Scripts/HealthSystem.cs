using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class HealthSystem : MonoBehaviour
{

    public float health = 10;
    public float healing_factor = 0;

    public GameObject player;
    public bool isPlayer = false;

    public float health_drain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            player.GetComponent<HealthSystem>().changeHealth(healing_factor);
            Object.Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        health -= health_drain * Time.fixedDeltaTime;
    }

    public void changeHealth(float deltaHealth) 
    {
        health = health + deltaHealth;
        Debug.Log(this.gameObject.name + " health: "+ health);
    }
}
