using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagivel : MonoBehaviour
{
    public GameObject armaPrefab;    

    public string descricao = "";

    //Itens de recuperacao
    public Jogador jogadorInt;

    public Vida vidaRecupera;
    public bool itemEspecial;
    public float recuperaVida;
    public float aumentaVida;
    public float recuperaBateria;
    public float aumentaBateria;


    

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    //Descrição do objeto de interação
    public string Descricao() { return descricao; }

    //Aqui decidimos o que o objeto faz de acordo com sua tag
    public void Acao()
    {
        // caso o objeto seja um coletável de arma ele ativa essa arma que já está no jogador mas não estava disponível
        if(gameObject.tag == "WeaponStation") {
            //aqui é o bool que verifica se a arma está no inventário, assim que coletada ela se torna verdadeiro no inventário
            armaPrefab.GetComponent<Arma>().armaNoInventario = true;
            //Ativa o prefab
            //armaPrefab.SetActive(true);
            //E destroi o objeto
            Destroy(gameObject);

            
        }
        if(gameObject.tag == "RecuperaVida")
        {
            if(!itemEspecial)vidaRecupera.AtualizaVida(recuperaVida);
            else if (itemEspecial)
            {
                vidaRecupera.AtualizaVida(vidaRecupera.maxVida);
                vidaRecupera.maxVida += aumentaVida;
            }
            Destroy(gameObject);
        }
        if (gameObject.tag == "RecuperaBateria")
        {
           if(!itemEspecial) jogadorInt.Bateria(recuperaBateria);
           else if(itemEspecial)
            {
                jogadorInt.Bateria(jogadorInt.maxBateria);
                jogadorInt.maxBateria += aumentaBateria;
            }
            Destroy(gameObject);
        }
        if(gameObject.tag == "CartaoAcesso")
        {
            jogadorInt.cartaoCor.a = 1f;
            jogadorInt.temCartaoacesso = true;
            Destroy(gameObject);
        }
        if(gameObject.name == "Portao")
        {
            DanoContinuo dano = GetComponent<DanoContinuo>();
            if (!dano.trancado) dano.interpolacao = true;
        }
        if(gameObject.name == "AcessCard")
        {
            if(jogadorInt.temCartaoacesso)
            {
                jogadorInt.temCartaoacesso = false;
                gameObject.GetComponent<Tranca>().Cartao();
            }
            
        }
    }
}
