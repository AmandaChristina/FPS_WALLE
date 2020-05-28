using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour
{
    public GameObject[] inimigo;
    public GameObject[] inimigosSpawn;

    int random;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnEnable()
    {
       
            for(int i = 0; i < inimigosSpawn.Length; i++)
            {
                Instantiate(inimigo[UnityEngine.Random.Range(0,2)], inimigosSpawn[i].transform.position, inimigosSpawn[i].transform.rotation);
            }
        
        //gameObject.SetActive(false);
    }
}
