using UnityEngine;

public class Coin : MonoBehaviour
{
    // A moeda agora procura o script 'Pontuacao'
    private Pontuacao pontuacaoScript;

    void Start() {
        pontuacaoScript = FindFirstObjectByType<Pontuacao>();
    }

    void Update() {
        // Como o player está parado, a moeda tem que vir na direção dele (Z negativo)
        // Vamos usar a mesma lógica do seu script Obstaculo
        transform.Translate(Vector3.back * 30f * Time.deltaTime);

        if (transform.position.z < -45f) {
            Destroy(gameObject);
        }
    }

    // Nota: Use OnTriggerEnter para 3D (seu Player já usa isso)
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (pontuacaoScript != null) {
                pontuacaoScript.AdicionarPonto();
            }
            Destroy(gameObject);
        }
    }
}