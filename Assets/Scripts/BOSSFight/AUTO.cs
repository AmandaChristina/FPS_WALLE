using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUTO : MonoBehaviour
{
    public enum Estados { ATIVAIMA, SPAWNINIMIGO, SPAWNOBJECTS, STUN};
    public Estados estado;

    public GameObject[] Imas;
    public GameObject[] Monitores;
    public GameObject Inimigo;
    public GameObject SpawnObjetos;

    Vida vidaIma;
    GameObject Jogador;

    public float ativaImacont;
    public float tempo;

    void Start()
    {
        Jogador = GameObject.Find("Player");
        
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



    void AtivaIma()
    {

        Ima imaPonta = Imas[0].GetComponentInChildren<Ima>();
        Vida imaVida = Imas[0].GetComponent<Vida>();
        CharacterController jogadorCC = Jogador.GetComponent<CharacterController>();


        imaPonta.enabled = true;
        if (imaVida.vida == 0) {

            if (jogadorCC.enabled == true)
            {
                imaPonta.enabled = false; 
            }
            imaVida.AtualizaVida(imaVida.maxVida);
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

    void Stun()
    {
        if (tempo < 16f)
        {
            tempo += Time.deltaTime;

        }

        else if (tempo > 15f)
        {
            
            TrocaEstado(Estados.SPAWNINIMIGO);
        }
    }

    void TrocaEstado(Estados proximo)
    {
        
        estado = proximo;
    }

    void VerificaVidaMonitor()
    {
        Vida vidaMonitor = Monitores[0].GetComponent<Vida>();
        if (vidaMonitor.vida == 0) {

            TrocaEstado(Estados.STUN);
        }
    }
    
}

