using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoScript : MonoBehaviour
{

    //Vector3 posicao;
    public float alcance;

    public Transform[] pontos;
    public GameObject tiroPrefab;
    GameObject jogador;
    public Transform spawn;
    NavMeshAgent agente;
    Vida vidaInimigo;
    public int indice;
    float rate;
    float resfriamento;
    public bool naMira;
    

    
    void Start()
    {
        jogador = GameObject.Find("Player");
        agente = GetComponent<NavMeshAgent>();
        //spawn = GetComponentInChildren<Transform>();
        
        //Vida
        vidaInimigo = GetComponent<Vida>();
        if (gameObject.CompareTag("Inimigo3")) vidaInimigo = GetComponentInChildren<Vida>();
    }

    
    void Update()
    {
        if (vidaInimigo.Morreu())
        {
            Destroy(gameObject, 1f);
            return;
        }

        RaycastMetod();

        if (transform.CompareTag("Inimigo2")) {
            
            //Máquina de Estados
            if (!naMira) Patrulheiro();
            else Perseguidor();
        }

        if (transform.CompareTag("Inimigo3"))
        {
            if (!naMira) Patrulheiro();
            else
            {
                Dash();
            }
        }


    }

    void Perseguidor(){
        Atirador();
        Quaternion alvoRot = Quaternion.LookRotation(jogador.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, alvoRot, 340 * Time.deltaTime);
        agente.SetDestination(jogador.transform.position);
        
        print("Mata o cara!!!");
    }
    void Patrulheiro(){
        if (agente.remainingDistance < 1f)
        {
            if (indice == pontos.Length - 1f) indice = 0;
            else indice++;
            agente.SetDestination(pontos[indice].position);
        }
    }
    void Atirador()
    {
        if (rate < Time.time)
        {
            rate = Time.time + 0.1f;

            GameObject tiroCopia = Instantiate(tiroPrefab, spawn.position, spawn.rotation);
            tiroCopia.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
            Destroy(tiroCopia, 6f);
        }

    }
    void RaycastMetod()
    {
        Vector3 alvo = jogador.transform.position - transform.position;
        Ray raio = new Ray(transform.position, alvo);
        Debug.DrawRay(raio.origin, raio.direction * alcance, Color.red);
        RaycastHit hit;

        naMira = false;

        //print("Área Limpa!!");

        if (Physics.Raycast(raio, out hit, alcance))
        {

           if(hit.transform.tag == "Player")  naMira = true;
        }
    }

    void Dash()
    {
        
            transform.position = Vector3.MoveTowards(transform.position, jogador.transform.position, Time.deltaTime * 10);
        

    }
}
