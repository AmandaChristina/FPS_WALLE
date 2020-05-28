using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenaGerenciador : MonoBehaviour
{
    public GameObject elevador;
    public GameObject portaElevador;
    public GameObject portaChefao;
    public GameObject Auto;
    float tempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Inimigo2") == null)
        {
            portaElevador.GetComponent<Interpolacao>().enabled = true;
        }

        if(elevador.transform.localPosition == elevador.GetComponent<Interpolacao>().posicaoFinal)
        {
            portaChefao.GetComponent<Interpolacao>().enabled = true;
        }

        if(portaChefao.transform.localPosition == portaChefao.GetComponent<Interpolacao>().posicaoFinal)
        {
            if(tempo < 5f)
            {
                tempo += Time.deltaTime;
            }
            else Auto.GetComponent<AUTO>().enabled = true;
        }
    }
}
