using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoParado : MonoBehaviour
{
    public GameObject tiroPrefab;
    public Transform spawnTiro;
    GameObject jogador;
    Vida vidaInimigo;

    bool encontrou;

    public float grau;
    float grauInicial;
    float inicial;
    public float distanciaRaio;


    void Start()
    {
        jogador = GameObject.Find("Player");
        vidaInimigo = GetComponent<Vida>();
        inicial = transform.eulerAngles.y;
        grauInicial = grau;   
    }

   
    void Update()
    {
        if (vidaInimigo.Morreu()) return;
        RaycastMetod();

        if (encontrou)
        {
            Quaternion alvo = Quaternion.LookRotation(jogador.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, alvo, 90 * Time.deltaTime);

            GameObject copiaTiro = Instantiate(tiroPrefab, spawnTiro.position, spawnTiro.rotation);
            copiaTiro.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
            Destroy(copiaTiro, 3f);
            // print("encontrei");
        }
        else if (!encontrou) 
        {
            //Corrigindo Rotação
            Vector3 projecao = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
            Quaternion rotacao = Quaternion.LookRotation(projecao);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacao, 30 * Time.deltaTime);
            MovimentoGiratorio();

            //print("não encontrei"); 
        }
    }

    void MovimentoGiratorio()
    {
        transform.Rotate(0, grau * Time.deltaTime, 0);
        //print(inicial);
        if (grauInicial > 0) { if (transform.eulerAngles.y < inicial) grau *= -1; }
        else if (grauInicial < 0) { if (transform.eulerAngles.y > inicial) grau *= -1; }
        if (inicial > 180)
        {
            if (transform.eulerAngles.y <= inicial - 180f) grau *= -1;
        }
        else
        {
            if (transform.eulerAngles.y >= inicial + 180f) grau *= -1;
        }
    }
    void RaycastMetod()
    {
        encontrou = false;
        //Ray raio = new Ray(transform.position, transform.forward * distanciaRaio);
        Ray raio = new Ray(transform.position, jogador.transform.position - transform.position);
        RaycastHit hit;
        Debug.DrawRay(raio.origin, raio.direction * distanciaRaio, Color.red);
        Vector3 alvo = jogador.transform.position - transform.position;

        if (Physics.Raycast(raio, out hit, distanciaRaio)){

            if (hit.transform == jogador.transform)
            {
                if (Vector3.Angle(alvo, transform.forward) < 45) encontrou = true;
                //encontrou = true;
            }    
        }

    }
}
