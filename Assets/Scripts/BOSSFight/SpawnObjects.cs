using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objetoPrefab;
    public GameObject[] objetosSpawn;

    int random;

    float tempo;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {

        StartCoroutine(SpawnObjetosMetodo());
        //gameObject.SetActive(false);
    }

    IEnumerator SpawnObjetosMetodo()
    {
        for (int i = 0; i < objetosSpawn.Length; i++)
        {
            GameObject copiaobjeto = Instantiate(objetoPrefab[0], objetosSpawn[i].transform.position, objetosSpawn[i].transform.rotation);
            yield return new WaitForSeconds(1);
            Destroy(copiaobjeto, 5f);
        }

    }
}
