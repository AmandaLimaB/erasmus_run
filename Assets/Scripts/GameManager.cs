using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para recarregar a fase

public class GameManager : MonoBehaviour
{
    public void FinalizarJogo()
    {
        Debug.Log("Game Over!");
        // Reinicia a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}