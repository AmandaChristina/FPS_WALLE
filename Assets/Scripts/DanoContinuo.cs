using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoContinuo : MonoBehaviour
{
    // Start is called before the first frame update

    public string descricaoAtual = "";
    
    public float danoporSegundo;
    public bool trancado;
    public bool interpolacao;
    void Start()
    {
        trancado = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!trancado) { 
            danoporSegundo = 0;
            Interagivel interagir = GetComponent<Interagivel>();
            interagir.enabled = true;
            interagir.descricao = descricaoAtual;
        }

        if (interpolacao)  GetComponent<Interpolacao>().enabled = true;
    }

   
}
