using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasBag : MonoBehaviour
{

    public int selecionaArma = 0;
    
    void Start()
    {
        //Começando com uma arma;
       // SelecionandoArma();
    }

    
    void Update()
    {

        int previsaoSelecionandoArma = selecionaArma;
        
        //Rodando Scroll pra cima
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            //Contando quantos items filhos tem no SeguraArma
            //Se seleciona Arma for igual a quantidade de items contadas, ele volta a selecionar o primeiro item
            if (selecionaArma >= transform.childCount - 1) selecionaArma = 0;
            //Caso não ele seleciona o próximo item
            else selecionaArma++;

        }

        //Rodando Scroll pra baixo
        if (Input.GetAxis("Mouse ScrollWheel") < 0f){
            //Se está no primeiro item, selecionará o último
            if (selecionaArma <= 0 ) selecionaArma = transform.childCount - 1;
            //caso não, selecionará a arma anterior
            else selecionaArma--;

        }

        //Guardando lógica, depois tornar mais automático
        //if (Input.GetKeyDown(KeyCode.Alpha1)) selecionaArma = 0;
        //if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2) selecionaArma = 1;

        if(previsaoSelecionandoArma != selecionaArma) SelecionandoArma();
       
    }

    void SelecionandoArma(){

        int i = 0;

        //Pegando todos os Transforms filhos e colocando no transform do objeto SeguraArma
        foreach (Transform arma in transform)
        {
            //Além de verificar se a arma selecionada é o mesmo do Loop, precisa verificar se ela está disponível
            //a quantidade de loop nesse caso vai depender sempre do selecionaArma que por sua vez depende da quantidade de itens filhos
            if (i == selecionaArma && arma.GetComponent<Arma>().armaNoInventario) arma.gameObject.SetActive(true);

            //Caso não seja, ela é desativada
            else arma.gameObject.SetActive(false);

            //Continua o Loop
            i++;
        }

    }
}
