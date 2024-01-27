using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class Pregunta
{
    public string enunciado;
    public string respuestaCorrecta;
    public string respuestaIncorrecta1;
    public string respuestaIncorrecta2;
}

public class Gem : MonoBehaviour
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
                enunciado = "¿Cuál es la montaña más alta del mundo?",
                respuestaCorrecta = "Everest",
                respuestaIncorrecta1 = "Kilimanjaro",
                respuestaIncorrecta2 = "Mont Blanc"
            },
            new Pregunta
            {
                enunciado = "¿Cuál fue la primera Expedición Antártica de Ernest Shackleton?",
                respuestaCorrecta = "Endurance",
                respuestaIncorrecta1 = "Discovery",
                respuestaIncorrecta2 = "Terra Nova"
            },
            new Pregunta
            {
                enunciado = "¿Cuál de los siguientes animales está adaptados a climas fríos?",
                respuestaCorrecta = "Oso polar",
                respuestaIncorrecta1 = "León africano",
                respuestaIncorrecta2 = "Elefante"
            },
            new Pregunta
            {
                enunciado = "¿Cuál es el deporte principal en Juegos Olímpicos de Invierno?",
                respuestaCorrecta = "Hockey sobre hielo",
                respuestaIncorrecta1 = "Atletismo",
                respuestaIncorrecta2 = "Fútbol"
            },
            new Pregunta
            {
                enunciado = "¿Cuál es la festividad asociada con invierno?",
                respuestaCorrecta = "Navidad",
                respuestaIncorrecta1 = "Halloween",
                respuestaIncorrecta2 = "Pascua"
            },
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
        Debug.Log(respuestaSeleccionada);
        if (respuestaSeleccionada == respuestaCorrecta)
        {
            premioPanel.SetActive(true);
            GameManager.Instance.SumarPuntos(500);
            premioText.text = "Respuesta Correcta!! Tu puntaje de este nivel es: " + GameManager.Instance.PuntosTotales.ToString();

        }
        else
        {
            premioPanel.SetActive(true);
            premioText.text = "Respuesta Incorrecta!! Tu puntaje de este nivel es: " + GameManager.Instance.PuntosTotales.ToString();
        }
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
