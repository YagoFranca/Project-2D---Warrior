using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{

    public GameObject Jogador;
    public NavMeshAgent IA;

    public int vidas;

    void Start()
    {
        //VIDA SERA SEMPRE A RELACAO ENTRE O NIVEL(WAVES)
        vidas = Pontuacao.nivel;
    }


    void Update()
    {
        //ENCONTRA O JOGADOR ATRAVES DA IA
        IA.SetDestination(Jogador.transform.position);

    }

    void OnCollisionEnter(Collision c)
    {
        //COLISAO COM O PROJETIL     
        if(c.collider.tag == "Personagem")
        {
            //DESCONTA A VIDA E VERIFICA SE TEM Q SER DESTRUIDO
            vidas--;
            if(vidas <= 0)
            {
                Destroy(gameObject);
            }
        }

        //DESTRUINDO O PERSONAGEM (DESTOI O PERSONAGEM E SUBRAI A VIDA)
        if (c.collider.tag == ("Personagem"))
        {
            Pontuacao.vidasJogador--;
            Destroy(gameObject);
        }
    }

   

}
