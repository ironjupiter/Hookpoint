using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public float health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            Object.Destroy(this.gameObject);
        }
    }

    public void changeHealth(float deltaHealth) 
    {
        health = health + deltaHealth;
        //Debug.Log(health + "health");
    }
}
