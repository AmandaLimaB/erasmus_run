using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaculoPrefab; // Arraste seu cubo azul aqui
    public float tempoEntreSpawn = 6f; // Segundos entre um cubo e outro
    public float variacaoX = 3f; // Largura da pista

    void Start()
    {
        // Chama a função de criar obstáculos repetidamente
        InvokeRepeating("Spawn", 0f, tempoEntreSpawn);
    }

    void Spawn()
    {
        // Define uma posição aleatória apenas no eixo X
        float posX = Random.Range(-variacaoX, variacaoX);
        float distanciaExtra = 40f;
        Vector3 posicao = new Vector3(posX, 0.5f, transform.position.z + distanciaExtra);

        // Cria o obstáculo
        Instantiate(obstaculoPrefab, posicao, Quaternion.identity);
    }
}