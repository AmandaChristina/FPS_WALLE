using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboCamera : MonoBehaviour
{
    public float grau;
    public GameObject jogador;
    public float alcance;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(grau* Time.time, Vector3.up);
        print(transform.eulerAngles.y);
        if (transform.eulerAngles.y < 180f)
        {
            grau *= -1;

        }



        //Alcance
        Vector3 alvo = jogador.transform.position - transform.position;
        Ray raio = new Ray(transform.position, alvo);
        Debug.DrawRay(raio.origin, raio.direction * alcance);
        RaycastHit hit;


        if(Physics.Raycast(raio, out hit, alcance))
        {
            transform.rotation = Quaternion.LookRotation(Time.deltaTime * jogador.transform.forward * -1);
        }
        
    }
}
