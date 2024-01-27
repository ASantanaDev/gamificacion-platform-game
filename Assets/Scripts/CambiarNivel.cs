using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour
{
    public GameObject nivel2;

    void Update()
    {
        DesbloquearNivel();
    }

    public void DesbloquearNivel()
    {
        if(PlayerPrefs.GetInt("PuntajeParaDesbloquear") >= 1000)
        {
            nivel2.SetActive(false);
        }
    }
    public void GoToLevel(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
