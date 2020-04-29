using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Slider barraVida;
    public float maxVida = 100;
    public float vida;
    

    void Start()
    {
        barraVida.maxValue = maxVida;
        vida = maxVida;
    }

  
    void Update()
    {

        barraVida.value = vida;
    }

    public void AtualizaVida(float atualvida)
    {
      vida += atualvida;
      vida = Mathf.Clamp(vida, 0, maxVida);
      
    }
}
