using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidade = 30f;
    private Rigidbody rb;

    void Start()
    {
        // Pega o componente Rigidbody que você adicionou no Unity
        rb = GetComponent<Rigidbody>();
    }

    // Usamos FixedUpdate para cálculos de física (exigência do enunciado!)
    void FixedUpdate()
    {
        // Move o obstáculo fisicamente dando velocidade ao corpo dele
        // Vector3.back é o mesmo que (0, 0, -1)
        rb.linearVelocity = Vector3.back * velocidade;

        // Se ele passou do jogador, remove o objeto para economizar memória
        if (transform.position.z < -45f)
        {
            Destroy(gameObject);
        }
    }
}