using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadeLateral = 10f; 
    public float velocidadeFrente = 5f;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movimentoFrente = transform.forward * velocidadeFrente * Time.fixedDeltaTime;
        float movimentoX = Input.GetAxis("Horizontal");
        Vector3 movimentoLateral = transform.right * movimentoX * velocidadeLateral * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimentoFrente + movimentoLateral);
    }

    void OnCollisionEnter(Collision colisor)
    {
        if (colisor.gameObject.CompareTag("Obstacle"))
        {
            if (FindObjectOfType<GameManager>() != null)
            {
                FindObjectOfType<GameManager>().FinalizarJogo();
            }
        }
    }
}