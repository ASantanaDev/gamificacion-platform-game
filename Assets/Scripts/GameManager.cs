using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public HUD hud;
    public GameObject gameoverPanel;
    public int PuntosTotales { get { return puntosTotales; }}

    private int vidas = 3;
    private int puntosTotales;
    public float tiempoEspera = 5f;

    private int score;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un GameManager en escena");
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        hud.ActualizarPuntos(puntosTotales);

    }

    public void TotalScore(int parcialScore)
    {
        score = PlayerPrefs.GetInt("TotalScore") + parcialScore;
        PlayerPrefs.SetInt("TotalScore", score);
    }

    public void PerderVida() {
		vidas -= 1;

		if(vidas == 0)
		{
            gameoverPanel.SetActive(true);
			Invoke("CargarEscena", tiempoEspera);
		}

		hud.DesactivarVida(vidas);
	}

    private void CargarEscena()
    {
        SceneManager.LoadScene(0);
    }

	public bool RecuperarVida() {
		if (vidas == 3)
		{
			return false;
		}

		hud.ActivarVida(vidas);
		vidas += 1;
		return true;
	}

}
