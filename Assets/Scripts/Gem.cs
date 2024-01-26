using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Gem : MonoBehaviour
{
    public TextMeshProUGUI preguntaText;
    public GameObject preguntaPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            preguntaPanel.SetActive(true);
            Time.timeScale = 0f;
        }
       
    }
}
