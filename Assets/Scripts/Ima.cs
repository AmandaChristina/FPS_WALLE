using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ima : MonoBehaviour
{
    Transform origem;
    BoxCollider colisao;
    GameObject jogadorDirecao;
    CharacterController jogadorCC;
    Vida vidaIma;
    Canvas vidaUI;

    Vector3 novaPosicaoJogador;

    public float alcance;

    bool abduzido;

   
    void Start(){
        origem = gameObject.transform;
        colisao = GetComponentInParent<BoxCollider>();
        jogadorDirecao = GameObject.Find("Player");
        jogadorCC = jogadorDirecao.GetComponent<CharacterController>();
        vidaIma = GetComponentInParent<Vida>();
        vidaUI = GetComponentInParent<Canvas>();
    }

    
    void Update(){
        //Tentando deixar a barra de vida na direção do jogador
        //FALTA PEGAR O COMPONENTE DA FORMA CORRETA
        //vidaUI.transform.rotation = Quaternion.LookRotation(jogadorDirecao.transform.eulerAngles * Time.deltaTime);

        //O imã só pode ser morto depois que o jogador for pego
        if (!abduzido) colisao.enabled = false;
        else colisao.enabled = true;

        //Ima morto
        if(vidaIma.vida == 0) {
            jogadorCC.enabled = true;
            if (vidaIma.Morreu()) return; 
        }

        //RayCast
        Vector3 direcao = jogadorDirecao.transform.position - origem.position;
        Ray raio = new Ray(origem.position, direcao);
        RaycastHit hit;
        Debug.DrawRay(raio.origin, raio.direction * alcance);
        
        print(" ");

        if(Physics.Raycast(raio, out hit, alcance))
        {
            if (hit.transform.name == "Player")
            {
                Abduzido();
            }

        }

    }


    void Abduzido(){
        abduzido = true;
        jogadorCC.enabled = false;
        novaPosicaoJogador = Vector3.MoveTowards(jogadorDirecao.transform.position, transform.position, Time.deltaTime * 10);
        jogadorDirecao.transform.position = novaPosicaoJogador;
        print("Jogador!!!");
    }
}
