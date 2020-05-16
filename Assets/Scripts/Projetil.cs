using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{

    public float velocidade;
    private int Dprojetil;
    
    void Start()
    {
        //Trava o eixos (eixo Z) para formar uma linha reta 
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //Aponto onde o jogador esta olhando
        Dprojetil = Hero.Dprojetil;

        //trava a rotacao do eixo Y e Z epara evitar rotacao
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);

        // Chamando a variavel de render e desligando a malha
        //GetComponent<Renderer>().enabled = false;

        //Remove o parentesco 
        transform.parent = null;
     
    }

   
    void Update()
    {
        //Mover o projetil
        transform.Translate(Dprojetil*transform.right* velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projetil>() == false || other.gameObject.GetComponent<Hero>() == false)
        {
            Destroy(gameObject);
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
        
    //    if (collision.collider.gameObject.GetComponent<Projetil>() == false|| collision.collider.gameObject.GetComponent<Hero>() == false)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
