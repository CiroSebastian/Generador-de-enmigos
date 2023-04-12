using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir este namespace

public class TextoPrueba : MonoBehaviour
{
    public Text miTexto;

    void Start()
    {
        miTexto.text = "Hola, mundo!"; 
    }
}
