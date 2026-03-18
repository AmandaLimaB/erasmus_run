using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidade = 30f;

    void Update()
    {
        // Move o obstáculo em direção ao jogador (Z negativo)
        transform.Translate(Vector3.back * velocidade * Time.deltaTime);

        // Se ele passou do jogador (Z < -10), some para sempre
        if (transform.position.z < -45f)
        {
            Destroy(gameObject);
        }
    }
}