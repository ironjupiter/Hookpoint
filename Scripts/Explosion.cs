using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update

    public float force = 1000;
    public float forceEffectiveLimit = .1f;
    private float range;

    private List<GameObject> hits = new List<GameObject>();
    void Start()
    {
        range = force / forceEffectiveLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Run") != 0)
        {
            Explode();
        }
    }
    
    void Explode()
    {
        int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(this.transform.position, range, hitColliders);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("hit");
            hits.Add(hitCollider.gameObject);
        }
        
        ForceObjects();
    }

    void ForceObjects()
    {
        foreach (GameObject go in hits)
        {
            Vector2 v2 =(-go.gameObject.transform.position + this.gameObject.transform.position);
            
            go.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(
                -force * v2.normalized * go.GetComponent<Rigidbody2D>().mass, this.transform.position);
        }

        //hits.RemoveAll(gameObject => gameObject);
    }
}
