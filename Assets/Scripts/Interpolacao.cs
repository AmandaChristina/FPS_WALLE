﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolacao : MonoBehaviour
{
    public Vector3 posicaoFinal;
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicaoFinal, Time.deltaTime * vel);
        
    }
}
