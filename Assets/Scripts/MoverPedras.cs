using UnityEngine;

public class MoverPedras : MonoBehaviour
{
    public float velocidade = 5f;
    public float tamanhoDoBloco; // Vamos preencher no Inspector

    void Update()
    {
        // Move para trás
        transform.Translate(0, 0, -velocidade * Time.deltaTime);

        // Se o bloco passou do ponto de reset
        if (transform.position.z <= -tamanhoDoBloco)
        {
            // Ele pula para a frente do OUTRO bloco.
            // Se o tamanho é 150, ele pula para 150.
            // Usamos transform.position.z + (tamanhoDoBloco * 2) para manter a precisão
            float novaPosicaoZ = transform.position.z + (tamanhoDoBloco * 2);
            transform.position = new Vector3(transform.position.x, transform.position.y, novaPosicaoZ);
        }
    }
}