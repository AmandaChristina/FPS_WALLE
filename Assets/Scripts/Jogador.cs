using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public Image cartaoAcesso;
    public Color cartaoCor;
    public Slider barraBateria;
    public float maxBateria;
    public float bateria;
    public bool temCartaoacesso;

    void Start()
    {
        cartaoCor = cartaoAcesso.color;
        cartaoCor.a = 0.3f;
        
        barraBateria.maxValue = maxBateria;
        bateria = maxBateria;
    }

    void Update()
    {
        cartaoAcesso.color = cartaoCor;
        barraBateria.value = bateria;

        if (!temCartaoacesso)
        {
            cartaoCor.a = 0.3f;
            cartaoAcesso.color = cartaoCor;
        }

    }

    //Só o Jogador tem gerenciamento de Bateria
    public void Bateria(float baterialAtual)
    {
        bateria += baterialAtual;
        bateria = Mathf.Clamp(bateria, 0f, maxBateria);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Eletrico")
        {
            Vida vida = GetComponent<Vida>();
            DanoContinuo dano = other.GetComponent<DanoContinuo>();
            vida.AtualizaVida(dano.danoporSegundo * Time.deltaTime);
        }
    }


}
