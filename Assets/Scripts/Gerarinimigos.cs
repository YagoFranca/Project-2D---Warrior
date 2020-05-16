using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerarinimigos : MonoBehaviour
{

    public GameObject inimigoPrefab;
    public float freqMin, freqMax;

    IEnumerator Start()
    {
        //SORTEIA UM VALOR MIN E MAN RANDOMICAMENTE, INSTANCIA SUA POSICAO EM UM LOOPING
        yield return new WaitForSeconds(Random.Range(freqMin,freqMax));
        Instantiate(inimigoPrefab, transform.position, transform.rotation);
        StartCoroutine(Start());
    }

   
}
