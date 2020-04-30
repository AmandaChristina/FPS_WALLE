using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboCamera : MonoBehaviour
{
    public float grau;
    public GameObject jogador;
    public GameObject tiroPrefab;
    public Transform spawnTiro;
    public float alcance;
    public float vel;
    bool encontrou;
    float rotacaoInicial;
    Vida vidaRobo;


    // Start is called before the first frame update
    void Start()
    {
        vidaRobo = GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaRobo.Morreu()) return;

        if (!encontrou)
        {
            vel = 1;

            Vector3 projecaoPlano = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
            Quaternion rotacaoNormal = Quaternion.LookRotation(projecaoPlano);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacaoNormal, grau * Time.deltaTime);
            transform.Rotate(0, 60 * Time.deltaTime, 0);
        }

        if (encontrou)
        {
            Quaternion jog = Quaternion.LookRotation(jogador.transform.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, jog, 90 * Time.deltaTime);

            vel = 10f;
            GameObject copiaTiro = Instantiate(tiroPrefab, spawnTiro.position, spawnTiro.rotation);
            copiaTiro.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
            Destroy(copiaTiro, 3f);
        }

        //Alcance
        Vector3 alvo = jogador.transform.position - transform.position;
        Ray raio = new Ray(transform.position, alvo);
        Debug.DrawRay(raio.origin, raio.direction * alcance);
        RaycastHit hit;


        if (Physics.Raycast(raio, out hit, alcance))
        {
            if (hit.transform == jogador.transform) {
                if (Vector3.Angle(alvo, transform.forward) < 45) encontrou = true;
            }
        }

    }
}
