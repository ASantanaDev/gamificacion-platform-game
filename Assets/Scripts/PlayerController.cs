using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public float fuerzaGolpe;
    public LayerMask capaSuelo;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private bool mirandoDerecha = true;
    private Animator animator;
    private bool puedeMoverse = true;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(
            boxCollider2D.bounds.center,
            new Vector2(boxCollider2D.bounds.size.x, boxCollider2D.bounds.size.y),
            0f,
            Vector2.down,
            0.2f,
            capaSuelo);

        return raycastHit2D.collider != null;
    }

    void ProcesarSalto()
    {

        if (Input.GetKeyDown(KeyCode.Space) && EstaEnSuelo())
        {
            rigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

        }
    }

    void ProcesarMovimiento()
    {
        if (!puedeMoverse) return;

        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        rigidbody2D.velocity = new Vector2(inputMovimiento * velocidad, rigidbody2D.velocity.y);

        GestionOrientacion(inputMovimiento);
    }

    void GestionOrientacion(float inputMovimiento)
    {
        if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }

    }

    public void AplicarGolpe()
    {
        puedeMoverse = false;

        Vector2 direccionGolpe;

        if (rigidbody2D.velocity.x > 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, 1);
        }

        rigidbody2D.AddForce(direccionGolpe * fuerzaGolpe);

        StartCoroutine(EsperarYActivarMovimiento());

    }

    IEnumerator EsperarYActivarMovimiento()
    {
        yield return new WaitForSeconds(0.1f);

        while (!EstaEnSuelo())
        {
            yield return null;
        }
        

        puedeMoverse = true;
    }

}
