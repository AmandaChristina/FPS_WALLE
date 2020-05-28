using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public Image cartaoAcesso;
    public Color cartaoCor;
    public Slider barraBateria;
    Vida vida;
    public float maxBateria;
    public float bateria;
    public bool temCartaoacesso;

    bool executando;

    Quaternion rot;
    Vector3 posicao;

    void Start()
    {
        vida = GetComponent<Vida>();
        cartaoCor = cartaoAcesso.color;
        cartaoCor.a = 0.3f;
        
        barraBateria.maxValue = maxBateria;
        bateria = maxBateria;
    }

    void Update()
    {
        if (vida.Morreu())
        {
            StartCoroutine(Checkpoint());
        }
        cartaoAcesso.color = cartaoCor;
        barraBateria.value = bateria;

        if (!temCartaoacesso)
        {
            cartaoCor.a = 0.3f;
            cartaoAcesso.color = cartaoCor;
        }

    }

    //Só o Jogador tem gerenciamento de Bateria
    public void Bateria(float baterialAtual)
    {
        bateria += baterialAtual;
        bateria = Mathf.Clamp(bateria, 0f, maxBateria);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Portao")
        {
             
            DanoContinuo dano = other.GetComponent<DanoContinuo>();
            vida.AtualizaVida(dano.danoporSegundo * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Tiro1")
        {
            //VIDA
           GetComponent<Vida>().AtualizaVida(-0.05f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Objeto")
        {
            //VIDA
            GetComponent<Vida>().AtualizaVida(-50f);
            //Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "Respawn")
        {
            rot = transform.rotation;
            posicao = transform.position;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Inimigo3")
        {
            //VIDA
            GetComponent<Vida>().AtualizaVida(-10f);

        }
    }

    IEnumerator Checkpoint()
    {
        if (!executando)
        {
            executando = true;

            GetComponent<CharacterController>().enabled = false;
            yield return new WaitForSeconds(1);

            transform.position = posicao;
            transform.rotation = rot;

            vida.AtualizaVida(vida.maxVida);
            GetComponent<CharacterController>().enabled = true;

            executando = false;
        }
    }


}
