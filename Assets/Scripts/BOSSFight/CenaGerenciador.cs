using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenaGerenciador : MonoBehaviour
{
    public GameObject elevador;
    public GameObject portaElevador;
    public GameObject portaChefao;
    public GameObject Auto;

    public Vector3 portaposicaoInicial;
    float tempo;
    // Start is called before the first frame update
    void Start()
    {
        portaposicaoInicial = portaChefao.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Inimigo2") == null &&
           GameObject.FindGameObjectWithTag("Inimigo1") == null &&
           GameObject.FindGameObjectWithTag("Inimigo3") == null)
        {
            portaElevador.GetComponent<Interpolacao>().enabled = true;
        }

        if(elevador.transform.localPosition == elevador.GetComponent<Interpolacao>().posicaoFinal)
        {
            portaChefao.GetComponent<Interpolacao>().enabled = true;
        }

        if(portaChefao.transform.localPosition == portaChefao.GetComponent<Interpolacao>().posicaoFinal)
        {
            if (tempo < 2f)
            {
                tempo += Time.deltaTime;
            }

            else
            {
                Auto.GetComponent<AUTO>().enabled = true;
                //Destroy(elevador.gameObject);
                Destroy(portaChefao);
                
            }
            
        }
        
    }
}
