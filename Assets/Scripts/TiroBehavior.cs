using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;

public class TiroBehavior : MonoBehaviour
{

    public Vector3 n_Target;
    public GameObject CollisionExplosion;
    public float speed;


    void Start()
    {
        
    }

    
    void Update()
    {
        float step = speed + Time.deltaTime;

        if(n_Target != null)
        {
            if(transform.position == n_Target)
            {
                explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, n_Target, step);
        }
    }

    public void setTarget(Vector3 target)
    {
        n_Target = target;
    }

    void explode()
    {
        if(CollisionExplosion != null)
        {
            GameObject explosion = (GameObject)Instantiate(CollisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }
    }
}
