using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interacao : MonoBehaviour
{
    //Limite da interação, fica mais fácil de refinar
    public float alcanceInteracao = 10f;
    public Text texto;
   
    void Start()
    {
        texto.text = " ";
    }

    void Update()
    {
        //Raycast próprio para a interação
        Ray origem = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit objeto;
        Debug.DrawRay(origem.origin, origem.direction * alcanceInteracao);

        //Aqui podemos buscar o método Acao()
        Interagivel seleciona = null;

        if (Physics.Raycast(origem, out objeto, alcanceInteracao)) {
            //Quando o raycast atingir o ojeto, ele deve pegar os componentes abaixo;
            seleciona = objeto.transform.GetComponent<Interagivel>();
        }

        //Caso a variavel não for nula, usaremos os métodos que contém no script que pegamos
        if (seleciona != null){
            //exibe o texto de descrição do script Interagivel
            texto.text = seleciona.Descricao();
            //Apertando E
            if (Input.GetKeyDown(KeyCode.E)){
                //Chama o método público Ação
                seleciona.Acao();
            }
        }
        //caso não selecionemos nada interagível nenhum texto irá aparecer na tela
        else texto.text = "";
    }

    
}
