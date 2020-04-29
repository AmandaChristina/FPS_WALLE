using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabeca : MonoBehaviour
{
    public Movimento sensibilidadeHead;
    float rotX;

    void Update()
    {
        //Aqui estamos além de controlando a visão, estamos limitando: não queremos que o jogador dê a volta na própria cabeça;
        //nesse caso precisa ser separado pois só queremos controlar a cabeça e não o corpo, diferente da rotação horizontal;

        rotX -= Input.GetAxis("Mouse Y") * sensibilidadeHead.sensibilidadeMouse * Time.deltaTime;
        rotX = Mathf.Clamp(rotX , -45f, 45f);
        transform.localEulerAngles = rotX * Vector3.right;
        
    }
}
