using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public Transform mira;
    public GameObject projetil;

    void Update()
    {
        //Input atirando
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(projetil, mira.transform);
        }

    }
}
