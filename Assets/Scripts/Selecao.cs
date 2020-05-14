using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecao : MonoBehaviour
{
    MeshRenderer renderer;
    bool selecionado;

 
    void Start(){ renderer = GetComponent<MeshRenderer>();}


     void LateUpdate(){ Selecionado();}

    public void Selecionar(){ selecionado = true;}

    void Selecionado(){
        if (selecionado){
            renderer.material.SetColor("_EmissionColor", Color.grey);
            renderer.material.EnableKeyword("_EMISSION");
        }
        else renderer.material.DisableKeyword("_EMISSION");
        selecionado = false;
    }
}
