using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenuInicial : MonoBehaviour
{
    public void Volvermenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void EscenasVolverMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);

    }   

}