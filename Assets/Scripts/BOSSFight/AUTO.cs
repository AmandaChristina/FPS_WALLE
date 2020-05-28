using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AUTO : MonoBehaviour
{
    public enum Estados { ATIVAIMA, SPAWNINIMIGO, SPAWNOBJECTS, STUN};
    public Estados estado;

    public GameObject[] Imas;
    public GameObject[] Monitores;
    public GameObject Inimigo;
    public GameObject SpawnObjetos;
    public GameObject alvoAuto;
    public Slider VidaUI;

    public Transform posicao1;
    public Transform posicao2;

    AUTO scriptAuto;
    Vida autoVida;
    Vida imaVida;
    GameObject Jogador;

    public float tempo;
    int contadorMaquina = 0;
    int imaContador = 0;

    void Start()
    {
        Jogador = GameObject.Find("Player");
        autoVida = alvoAuto.GetComponent<Vida>();
        scriptAuto = GetComponent<AUTO>();
        VidaUI.enabled = true;
        alvoAuto.SetActive(false);
        
        
    }

    
    void Update()
    {
        switch (estado)
        {
            case Estados.ATIVAIMA:
                AtivaIma();
                break;

            case Estados.SPAWNINIMIGO:
                SpawnInimigo();
                break;
            case Estados.SPAWNOBJECTS:
                SpawnObjects();
                break;
            case Estados.STUN:
                Stun();
                break;


        }

        VerificaVidaMonitor();
    }



    
    void Stun()
    {
        //if (GameObject.FindGameObjectWithTag("Inimigo3") == null &&
        //    GameObject.FindGameObjectWithTag("Inimigo2") == null)
        //{
        //    Inimigo.SetActive(false);
        //}
        //if (GameObject.FindGameObjectWithTag("Objeto") == null)
        //{
        //    SpawnObjetos.SetActive(false);
        //}

        if (tempo < 5f)
        {
            tempo += Time.deltaTime;
            alvoAuto.SetActive(true);
        }
        else {
            tempo = 0;
            alvoAuto.SetActive(false);
            print("já saiu da condição");
            TrocaEstado(Estados.SPAWNINIMIGO);
        }

    }
    void SpawnInimigo()
    {
        
        Inimigo.SetActive(true);
        
        if (GameObject.FindGameObjectWithTag("Inimigo3") == null &&
            GameObject.FindGameObjectWithTag("Inimigo2") == null)
        {
            Inimigo.SetActive(false);
            TrocaEstado(Estados.SPAWNOBJECTS);

        }
        
    }

    void SpawnObjects()
    {
        SpawnObjetos.SetActive(true);

        if (GameObject.FindGameObjectWithTag("Objeto") == null)
        {
            SpawnObjetos.SetActive(false);
            TrocaEstado(Estados.ATIVAIMA);
        }
    }
    void AtivaIma()
    {
        if(imaContador > 1 )
        {
            imaContador = 0;
        }
        Ima imaPonta = imaPonta = Imas[imaContador].GetComponentInChildren<Ima>();

        CharacterController jogadorCC = Jogador.GetComponent<CharacterController>();
        imaVida = Imas[imaContador].GetComponent<Vida>();

        imaPonta.enabled = true;

        if (imaVida.vida == 0)
        {

            if (jogadorCC.enabled == true)
            {
                imaPonta.enabled = false;
                imaContador++;
            }
            imaVida.AtualizaVida(imaVida.maxVida);
            TrocaEstado(Estados.SPAWNINIMIGO);
        }
    }


    void TrocaEstado(Estados proximo)
    {
        
        estado = proximo;
    }

    void VerificaVidaMonitor()
    {
        if(contadorMaquina >= Monitores.Length)
        {
            alvoAuto.SetActive(true);
            MovimentaBOSS();
        }

        Vida vidaMonitor = Monitores[contadorMaquina].GetComponent<Vida>();
        if (vidaMonitor.vida == 0) {

            
            contadorMaquina++;
            TrocaEstado(Estados.STUN);
            
        }

        if (autoVida.vida == 0) {

            scriptAuto.enabled = false;
            SceneManager.LoadScene("Vitoria");

        }
    }

    void MovimentaBOSS()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicao1.position, 2f);

        if(transform.position == posicao1.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicao2.position, 2f);
        }


    }
    
}

