using UnityEngine;
using UnityEngine.SceneManagement; // Importante para trocar de cena

public class GerenciadorCenas : MonoBehaviour
{
    public void IrParaScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}