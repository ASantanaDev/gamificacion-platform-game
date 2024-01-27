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

    private List<Pregunta> preguntas;
    private Pregunta preguntaActual;
    private string respuestaCorrecta;

    void Start()
    {
        poolPreguntas();
    }

    private void poolPreguntas()
    {
        preguntas = new List<Pregunta>
        {
            new Pregunta
            {
                enunciado = "¿Qué tipo de árbol es conocido por ser perenne y mantener sus hojas durante todo el año?",
                respuestaCorrecta = "Pino",
                respuestaIncorrecta1 = "Sauce",
                respuestaIncorrecta2 = "Abedul"
            },
            new Pregunta
            {
                enunciado = "¿Cuál es el término para la relación simbiótica entre un hongo y las raíces de un árbol?",
                respuestaCorrecta = "Micorriza",
                respuestaIncorrecta1 = "Líquenes",
                respuestaIncorrecta2 = "Parásito"
            },
            new Pregunta
            {
                enunciado = "¿En qué región se encuentra la famosa Selva Negra conocida por sus densos bosques?",
                respuestaCorrecta = "Alemania",
                respuestaIncorrecta1 = "Brasil",
                respuestaIncorrecta2 = "Canadá"
            },
            new Pregunta
            {
                enunciado = "¿Qué actividad recreativa implica caminar por senderos en áreas boscosas?",
                respuestaCorrecta = "Senderismo",
                respuestaIncorrecta1 = "Surf",
                respuestaIncorrecta2 = "Paracaidismo"
            },
            new Pregunta
            {
                enunciado = "¿En qué mitología se menciona el Bosque de Sherwood como el hogar de Robin Hood?",
                respuestaCorrecta = "Inglesa",
                respuestaIncorrecta1 = "Griega",
                respuestaIncorrecta2 = "Nórdica"
            },
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            preguntaPanel.SetActive(true);
            premioPanel.SetActive(false);
            Time.timeScale = 0f;

            preguntaActual = preguntas[UnityEngine.Random.Range(0, preguntas.Count)];

            preguntaText.text = preguntaActual.enunciado;

            List<string> respuestas = new List<string>
            {
                preguntaActual.respuestaCorrecta,
                preguntaActual.respuestaIncorrecta1,
                preguntaActual.respuestaIncorrecta2
            };
            respuestas = Shuffle(respuestas);

            respuestaAText.text = respuestas[0];
            respuestaBText.text = respuestas[1];
            respuestaCText.text = respuestas[2];

            respuestaCorrecta = preguntaActual.respuestaCorrecta;

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
        if(respuestaSeleccionada == respuestaCorrecta){
            premioPanel.SetActive(true);
            GameManager.Instance.SumarPuntos(500);
            premioText.text = "Respuesta Correcta!! Tu puntaje de este nivel es: " + GameManager.Instance.PuntosTotales.ToString();
            
        }
        else{
            premioPanel.SetActive(true);
            premioText.text = "Respuesta Incorrecta!! Tu puntaje de este nivel es: " + GameManager.Instance.PuntosTotales.ToString();
        }

        GameManager.Instance.TotalScore(GameManager.Instance.PuntosTotales);
        PlayerPrefs.SetInt("PuntajeParaDesbloquear", GameManager.Instance.PuntosTotales);
        PlayerPrefs.SetInt("SuperarNivel1", 1);
        Debug.Log(PlayerPrefs.GetInt("TotalScore"));
        
    }

    private List<T> Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }
}
