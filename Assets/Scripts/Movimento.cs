using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    CharacterController jogador;

    public float velocidade = 10f;
    public float sensibilidadeMouse = 100f;
    public float forcaPulo;

    float pulo;
    float rotY;
    float gravidade = 50f;
    

    Vector3 move;


    void Start()
    {
        //Travando cursor no meio da tela
        Cursor.lockState = CursorLockMode.Locked;
        jogador = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        //------------------------CURSOR
        //Quando damos locked mode, o cursor fica invisível;
        //Esse comando só funciona no Update
        //Cursor.visible = true;


        Rotacao();
        Mover();
       
    }

    void Rotacao()
    {
        //------------------------ROTAÇÃO
        //Rotacionando o jogador!
        //o Script Visão, rotaciona a câmera apenas e impôe limites
        //Input do mouse no X para implementar no Z do jogador, assim é intuitivo para o jogador;
        rotY = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        //Atribuição
        transform.Rotate(0, rotY * Time.deltaTime, 0);

    }
    void Mover()
    {
        //------------------------PULO
        //O character controller não tem gravidade então pra considerar pulo e consequentemente queda, precisamos fazer nossa própria gravidade;
        //Se o jogador está no chão
        if (jogador.isGrounded)
        {
            pulo = 0;
            if (Input.GetKeyDown(KeyCode.Space)) pulo = forcaPulo;
        }
        pulo -= gravidade * Time.deltaTime;


        //------------------------MOVIMENTO
        //Garante zerar a movimentação do jogador quando os Inputs não forem recebidos

        //Inputs
        //move += Input.GetAxis("Horizontal") * transform.right * velocidade;
        //move += Input.GetAxis("Vertical") * transform.forward * velocidade;
        move = Vector3.zero;
        move += Input.GetAxis("Horizontal") * transform.right * velocidade;
        move += Input.GetAxis("Vertical") * transform.forward * velocidade;
        move += pulo * Vector3.up;
        //Atribuição de movimento
        jogador.Move(move * Time.deltaTime);
        
    }
}
