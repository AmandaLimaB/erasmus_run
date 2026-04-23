using UnityEngine;

public class RotacaoMoeda : MonoBehaviour
{
    [Header("Configurações de Giro")]
    public float velocidadeGiro = 180f; // Graus por segundo

    void Update()
    {
        // Space.Self faz ela girar no próprio eixo
        // Vector3.up faz ela girar como um pião (eixo Y)
        transform.Rotate(Vector3.up * velocidadeGiro * Time.deltaTime, Space.Self);
    }
}