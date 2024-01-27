using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour
{
    public GameObject nivel2;
    public GameObject logro1, logro2, logro3;

    void Update()
    {
        DesbloquearNivel();
        DesbloquearLogro1();
    }

    public void DesbloquearNivel()
    {
        if(PlayerPrefs.GetInt("PuntajeParaDesbloquear") >= 1000)
        {
            logro2.SetActive(true);
            nivel2.SetActive(false);
        }
    }
    public void GoToLevel(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void DesbloquearLogro1()
    {
        if(PlayerPrefs.GetInt("SuperarNivel1") == 1)
        {
            logro1.SetActive(true);
        }
    }

    public void DesbloquearLogro3()
    {
        if(PlayerPrefs.GetInt("SuperarNivel2") == 1)
        {
            logro3.SetActive(true);
        }
    }
}
