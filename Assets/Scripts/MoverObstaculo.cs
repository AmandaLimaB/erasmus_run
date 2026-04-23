using UnityEngine;

public class MoverObstaculo : MonoBehaviour
{
    public float velocidade = 20f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true; 
        }
    }

    void Update()
    {
        // ADICIONADO: Space.World
        // Isso impede que a rotação da moeda mude a direção do movimento
        transform.Translate(Vector3.back * velocidade * Time.deltaTime, Space.World);

        // Destrói o objeto quando ele passar do jogador
        if (transform.position.z < -40f)
        {
            Destroy(gameObject);
        }
    }
}