using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class GemG : MonoBehaviour
{
    public TextMeshProUGUI preguntaText;
    public TextMeshProUGUI respuestaAText;
    public TextMeshProUGUI respuestaBText;
    public TextMeshProUGUI respuestaCText;
    public TextMeshProUGUI premioText;
    public GameObject preguntaPanel;
    public GameObject premioPanel;

    private string respuestaCorrecta;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            preguntaPanel.SetActive(true);
            premioPanel.SetActive(false);
            Time.timeScale = 0f;

            preguntaText.text = "¿Qué tipo de árbol es conocido por ser perenne y mantener sus hojas durante todo el año?";
            respuestaAText.text = "Sauce";
            respuestaBText.text = "Pino";
            respuestaCText.text = "Abedul";

            respuestaCorrecta = "Pino";

        }
       
    }

    public void OnClickRespuestaA()
    {
        VerificarRespuesta(respuestaAText.text);
    }

    public void OnClickRespuestaB()
    {
        VerificarRespuesta(respuestaBText.text);
    }

    public void OnClickRespuestaC()
    {
        VerificarRespuesta(respuestaCText.text);
    }

    public void VerificarRespuesta(string respuestaSeleccionada)
    {
        Debug.Log(respuestaSeleccionada);
        if(respuestaSeleccionada == respuestaCorrecta){
            premioPanel.SetActive(true);
            premioText.text = "Respuesta Correcta!! :D";
            
        }
        else{
            premioPanel.SetActive(true);
            premioText.text = "Respuesta Incorrecta!! D:";
        }
    }
}
