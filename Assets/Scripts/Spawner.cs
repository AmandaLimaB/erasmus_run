using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Configurações de Prefabs")]
    public GameObject obstaculoPrefab;
    public GameObject moedaPrefab;

    [Header("Configurações do Jogo")]
    public float tempoEspera = 0.5f; 
    [Range(0, 1)] public float chanceObstaculo = 0.7f;

    [Header("Configurações de Pistas")]
    public float larguraPista = 3f; 

    private float cronometro;

    void Update()
    {
        cronometro += Time.deltaTime;

        if (cronometro >= tempoEspera)
        {
            SpawnAleatorio();
            cronometro = 0f;
        }
    }

    void SpawnAleatorio()
    {
        // Sorteia a pista (-1, 0 ou 1) e multiplica pela largura
        int pistaSorteada = Random.Range(-1, 2); 
        float posicaoX = pistaSorteada * larguraPista;

        float sorteioTipo = Random.value;

        // Usa a posição Z do Spawner para que eles não nasçam no ponto 0
        Vector3 posicaoSpawn = new Vector3(posicaoX, transform.position.y, transform.position.z);

        if (sorteioTipo <= chanceObstaculo)
        {
            Instantiate(obstaculoPrefab, posicaoSpawn, Quaternion.identity);
        }
        else
        {
            // Altura ajustada para a moeda não ficar no chão
            float alturaFixaMoeda = 1.2f; 
            Vector3 posicaoMoeda = new Vector3(posicaoX, alturaFixaMoeda, transform.position.z);
            
            Instantiate(moedaPrefab, posicaoMoeda, Quaternion.identity);
        }
    }
}