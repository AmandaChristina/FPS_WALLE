using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranca : MonoBehaviour
{
    public GameObject alimentado;
    public GameObject animacaoCartao;
    Vida vidaFonte;
    // Start is called before the first frame update
    void Start()
    {
        vidaFonte = GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "FonteDeEnergia") { 

            if(vidaFonte.vida <= 0)
            {
                alimentado.GetComponent<DanoContinuo>().trancado = false;

            }
        }
        if(gameObject.name == "AcessCard")
        {
            
        }
    }

    public void Cartao()
    {
        
        alimentado.GetComponent<DanoContinuo>().trancado = false;
        animacaoCartao.SetActive(true);
        Destroy(animacaoCartao, 2f);
    }
}
