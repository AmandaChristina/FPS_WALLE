using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo2 : MonoBehaviour
{

    //Vector3 posicao;
    public float alcance;

    public Transform[] pontos;
    public GameObject tiroPrefab;
    GameObject jogador;
    Transform spawn;
    NavMeshAgent agente;
    Vida vidaInimigo;
    public int indice;
    float rate;
    bool naMira;
    

    
    void Start()
    {
        jogador = GameObject.Find("Player");
        agente = GetComponent<NavMeshAgent>();
        spawn = GetComponentInChildren<Transform>();
        vidaInimigo = GetComponent<Vida>();
        //agente.SetDestination(pontos[indice].position);
    }

    
    void Update()
    {
        if (vidaInimigo.Morreu()) {
            Destroy(gameObject, 3f);
            return; 
        }

        RaycastMetod();

        //Máquina de Estados
        if (!naMira) Patrulheiro();
        else Perseguidor();
    }

    void Perseguidor(){

        Quaternion alvoRot = Quaternion.LookRotation(jogador.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, alvoRot, 180 * Time.deltaTime);
        agente.SetDestination(jogador.transform.position);
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
            naMira = true;
            Atirador();
            //print("Mata o cara!!");
        }
    }
}
