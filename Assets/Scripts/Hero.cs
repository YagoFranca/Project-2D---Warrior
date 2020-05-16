using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public Transform cam;
    public float distanciaCameraX;
    public float velocidadeCamera;

    public GameObject personagem;
    public float velocidade;
    public static GameObject AlvoInimigo;
    public static int Dprojetil = 1;      // apontando a direcao do tiro

    private Animation anim;
    private AudioSource _audio;

    void Start()
    {
        //DEIXANDO A VARIAVEL PUBLICA PARA O INIMIGO ENCONTRAR O JOGADOR
        AlvoInimigo = this.gameObject;

        // OBTEM O COMPONENTE DE ANIMACAO DA MALHA DO PERSONAGEM
        anim = personagem.GetComponent<Animation>();

        // DESLIGA O RENDER DO CUBO (ANCORA)
        GetComponent<Renderer>().enabled = false;
        _audio = GetComponent<AudioSource>();

    }

    void Update()
    {
        //CAMERA
        float d = transform.position.x - cam.transform.position.x;   //PEGA A DIFERENÇA DE DISTANCIA ENTRE A CAMERA E O JOGADOR

        if(Mathf.Abs(d) > distanciaCameraX)                          //CONTROLE DA CAMERA FREEZANDO AS POSIÇÕES Y E Z MULTIPLICANDO A VELOCIDADE DELE EM TEMPO REAL 
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z), velocidadeCamera * Time.deltaTime);
        }
                       
        // MOVER
        float mover = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(mover, 0.0f, 0.0f);

        print(mover);

        //DIRECAO DO PROJETIL
        if (mover > 0)
        {
            Dprojetil = 1;
        }
        else if (mover < 0)
        {
            Dprojetil = -1;
        }

        //ANIMACAO ATIRAR PARADO
        if (Input.GetButtonDown("Jump") && mover == 0.0f)
        {
            anim.CrossFade("FIRE");
        }

        //SOM DO PERSONAGEM CORRENDO
        if (mover != 0.0f && !_audio.isPlaying)
        {
            _audio.Play();
        }

        // ANIMACAO DE RUN E IDLE
        if (Mathf.Abs(mover) > 0)
        {
            anim.CrossFade("RUN");
            
        }
        else if(mover == 0.0f)
        {
            if (anim.IsPlaying("FIRE") != true)
            {
                anim.CrossFade("IDLE");
            }
           
        }
        

      
        // ORIENTACAO
        if(mover < 0.0f)
        {
            personagem.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);
        }
        else if(mover > 0.0f)
        {
            personagem.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
        }
      
    }
}
