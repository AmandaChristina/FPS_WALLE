using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ima : MonoBehaviour
{
    public Transform origem;
    public GameObject jogadorDirecao;
    public float alcance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direcao = jogadorDirecao.transform.position - origem.transform.position;
        Ray raio = new Ray(origem.transform.position, direcao);
        RaycastHit hit;
        Debug.DrawRay(raio.origin, raio.direction * alcance);

        if(Physics.Raycast(raio, out hit, alcance))
        {
            if (hit.transform.name == "Player") print("Jogador!!!");
        }

    }
}
