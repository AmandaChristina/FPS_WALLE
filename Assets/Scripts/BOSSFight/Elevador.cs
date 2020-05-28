using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    Interpolacao animacao;
    Vector3 posicaoInicial;
    // Start is called before the first frame update
    void Start()
    {
        animacao = GetComponent<Interpolacao>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            animacao.enabled = true;
        }
    }
}
