using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float cooldownAtaque;
    public AudioClip sonidoAtaque;
    private bool puedeAtacar = true;
    private SpriteRenderer spriteRenderer;

    public GameObject Personaje;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        vistaEnemigo();
    }

    void vistaEnemigo(){
        Vector3 direccion = Personaje.transform.position - transform.position;
        if (direccion.x >= 0.0f){
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else{
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("Player")) {
            AudioManager.Instance.ReproduceSonido(sonidoAtaque);
			if(!puedeAtacar) return;

            puedeAtacar = false;

            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            
            GameManager.Instance.PerderVida();

            other.gameObject.GetComponent<PlayerController>().AplicarGolpe();

            Invoke("ReactivarAtaque", cooldownAtaque);
		}
	}

    void ReactivarAtaque(){
        puedeAtacar = true;

        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;

    }


}
