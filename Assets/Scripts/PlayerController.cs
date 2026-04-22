using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public AudioClip somBatida;
    public float velocidade = 5f;
    public GameManager gameManager; // Nota: Veja se você ainda está usando esse GameManager, se não, pode remover.
    
    private Animator anim; // Variável para guardar o componente de animação

    void Start()
    {
        // Procuramos o Animator no modelo 3D que está dentro (filho) do Player
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        // Movimento lateral
        transform.Translate(x * velocidade * Time.deltaTime, 0, 0);

        // Se o animator existir, avisamos que ele deve estar correndo
        if (anim != null) 
        {
            // Aqui você ativaria os parâmetros da animação se necessário
        }
    }

    // --- AQUI ESTÁ A MUDANÇA PRINCIPAL ---
    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Obstacle"))
    { 
        // 1. Toca o som (usando PlayClipAtPoint para garantir a persistência)
        if (somBatida != null)
        {
            AudioSource.PlayClipAtPoint(somBatida, Camera.main.transform.position);
        }

        Debug.Log("Bateu! Aguardando o som para carregar Game Over...");

        // 2. AGENDAMENTO: Espera 0.3 segundos e chama a função de carregar a cena
        // Isso dá tempo do áudio tocar antes da cena ser destruída
        Invoke("CarregarCenaGameOver", 0.3f); 
        
        // IMPORTANTE: Desativamos o movimento do player para ele não continuar 
        // andando durante esse pequeno atraso do som
        this.enabled = false; 
    }
}

// 3. NOVA FUNÇÃO: Ela será chamada pelo Invoke acima
void CarregarCenaGameOver()
{
    // O nome aqui deve ser EXATAMENTE o nome da sua cena no Build Settings
    SceneManager.LoadScene("GameOver");
}

    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Pickup"))
        {
            // Para garantir que o pickup seja destruído e o script Pontuacao funcione
            if (FindObjectOfType<Pontuacao>() != null)
            {
                FindObjectOfType<Pontuacao>().AdicionarPonto();
            }
            Destroy(outro.gameObject);
        }
    }
}