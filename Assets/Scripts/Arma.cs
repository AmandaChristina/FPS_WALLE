using UnityEngine;
public class Arma : MonoBehaviour
{
    public bool armaNoInventario;

    public GameObject mira, cursorUI;
    public GameObject tiro;

    public Transform tiroCordenada;
    Jogador player;
    

    public float alcance;
    public float poderDeFogo;
    public float consumoBateria;

    // Start is called before the first frame update
    void Start(){

        player = GameObject.Find("Player").GetComponent<Jogador>();


    }

    // Update is called once per frame
    void Update(){
        

        if (transform.name == "WallE"){
            if (Input.GetMouseButton(0)){
                RayCastArma();
                TiroEVA();
            }
        }
        else{
            if (Input.GetMouseButtonDown(0)){
                RayCastArma();
                TiroEVA();
            }
        }
    }

    void OnEnable(){
        cursorUI.SetActive(false);
        mira.SetActive(true);
    }

    void OnDisable(){

        cursorUI.SetActive(true);
        mira.SetActive(false);
    }

    void TiroEVA(){
        if (player.bateria > 0)
        {
            // Vector2 posicaoMira = new Vector2(Screen.width/2 , Screen.height / 2);
            //Ray alvo = Camera.main.ScreenPointToRay(posicaoMira);
            GameObject copiaTiro = Instantiate(tiro, tiroCordenada.position, tiroCordenada.rotation);
            copiaTiro.GetComponent<Rigidbody>().AddForce(tiroCordenada.forward * 500f);
            player.Bateria(consumoBateria);
            Destroy(copiaTiro, 3);
        }
        else print("sem bateria!!");
    }

    void RayCastArma(){

        Ray alvo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitalvo;
        Debug.DrawRay(alvo.origin, alvo.direction * alcance);

        Vida vidaAlvo = null;

        if (Physics.Raycast(alvo, out hitalvo, alcance)){
            vidaAlvo = hitalvo.transform.GetComponent<Vida>();
           
            if (vidaAlvo != null && vidaAlvo.vida > 0 && player.bateria > 0)
            {
                vidaAlvo.AtualizaVida(poderDeFogo);
            }
        }
    }



}
