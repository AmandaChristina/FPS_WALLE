using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleHindu : MonoBehaviour
{
    public Canvas puzzle1Canva;
    public GameObject[] imagens;
    public Transform[] posicoes_atuais;
    public Vector3[] posicoes_iniciais;
    Vector3 posicao;
    Quaternion rot;
   // GameObject pai;
    Button filho;
   // string nomeBotao;
    public int clique = 1;
    public int contadorAcertos = 0;
    public bool concluido;

    void Start()
    {
        
        //Posicoes Iniciais;
        for(int b = 0; b < posicoes_atuais.Length; b++)
        {
            posicoes_iniciais[b] = posicoes_atuais[b].position;
            print(posicoes_iniciais[b]);
        }

    }


    void Update()
    {


        if (concluido)  puzzle1Canva.enabled = false;
        
       
    }



    public void Imprimir(Button buton)
    {
        if(clique == 1)
        {
            filho = buton.GetComponent<Button>();
            //print(filho.name);
            clique++;
        }
        else if (clique == 2)
        {
            //guarda a posic
            posicao = buton.transform.position;
            rot = buton.transform.rotation;

            buton.transform.SetPositionAndRotation(filho.transform.position, filho.transform.rotation);
            filho.transform.SetPositionAndRotation(posicao, rot);
            for(int i = 0; i < posicoes_iniciais.Length; i++) {
                if (imagens[i].transform.position == posicoes_iniciais[i]) contadorAcertos++;
                else contadorAcertos = 0;
            }

            if (contadorAcertos >= posicoes_iniciais.Length) concluido = true;
            else concluido = false;
            
            clique = 1;
        }
        #region logicas
        //posicao = buton.transform.position;
        //rot = buton.transform.rotation;
        //transform.SetPositionAndRotation()
        //print(posicao + ", " + rot);

        //PERFECT
        //print(buton.transform.parent.name);
        //foreach (Button imagens in transform)
        //{
        //}
        //
        //nomeBotao = buton.name;
        //pai = GameObject.Find(buton.transform.parent.name);
        //print(pai.name);
        //print(pai.transform.childCount);
        //print(buton.name);
        #endregion
    }
}
