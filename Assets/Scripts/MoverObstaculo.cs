using UnityEngine;

public class MoverObstaculo : MonoBehaviour
{
    public float velocidade = 20f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Se por acaso você esqueceu de tirar a gravidade no Unity, 
        // o código faz isso agora para garantir.
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true; 
        }
    }

    void Update()
    {
        // Se o Rigidbody falhar, usamos o Translate como plano B
        // Isso garante que o objeto VAI se mover de qualquer jeito
        transform.Translate(Vector3.back * velocidade * Time.deltaTime);

        // Destrói o objeto quando ele passar muito do jogador
        if (transform.position.z < -40f)
        {
            Destroy(gameObject);
        }
    }
}