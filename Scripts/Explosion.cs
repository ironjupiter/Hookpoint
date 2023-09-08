using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update

    public float force = 1000;
    public float forceEffectiveLimit = .1f;
    private float range;
    void Start()
    {
        range = force / forceEffectiveLimit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
